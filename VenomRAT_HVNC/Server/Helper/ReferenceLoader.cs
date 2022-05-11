using System;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting;

namespace VenomRAT_HVNC.Server.Helper
{
    public class ReferenceLoader : MarshalByRefObject
    {
        public string[] LoadReferences(string assemblyPath)
        {
            string[] result;
            try
            {
                Assembly assembly = Assembly.ReflectionOnlyLoadFrom(assemblyPath);
                string[] array = (from x in assembly.GetReferencedAssemblies()
                                  select x.FullName).ToArray<string>();
                result = array;
            }
            catch
            {
                result = null;
            }
            return result;
        }

        public void AppDomainSetup(string assemblyPath)
        {
            try
            {
                AppDomainSetup info = new AppDomainSetup
                {
                    ApplicationBase = AppDomain.CurrentDomain.BaseDirectory
                };
                AppDomain domain = AppDomain.CreateDomain(Guid.NewGuid().ToString(), null, info);
                ObjectHandle objectHandle = Activator.CreateInstance(domain, typeof(ReferenceLoader).Assembly.FullName, typeof(ReferenceLoader).FullName, false, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic, null, null, CultureInfo.CurrentCulture, new object[0]);
                ReferenceLoader referenceLoader = (ReferenceLoader)objectHandle.Unwrap();
                string[] array = referenceLoader.LoadReferences(assemblyPath);
                AppDomain.Unload(domain);
            }
            catch
            {
            }
        }
    }
}
