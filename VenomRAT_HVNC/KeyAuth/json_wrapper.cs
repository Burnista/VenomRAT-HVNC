using System;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace KeyAuth
{
	// Token: 0x02000014 RID: 20
	public class json_wrapper
	{
		// Token: 0x0600008B RID: 139 RVA: 0x0000419F File Offset: 0x0000419F
		public static bool is_serializable(Type to_check)
		{
			return to_check.IsSerializable || to_check.IsDefined(typeof(DataContractAttribute), true);
		}

		// Token: 0x0600008C RID: 140 RVA: 0x000041BC File Offset: 0x000041BC
		public json_wrapper(object obj_to_work_with)
		{
			this.current_object = obj_to_work_with;
			Type type = this.current_object.GetType();
			this.serializer = new DataContractJsonSerializer(type);
			if (!json_wrapper.is_serializable(type))
			{
				throw new Exception(string.Format("the object {0} isn't a serializable", this.current_object));
			}
		}

		// Token: 0x0600008D RID: 141 RVA: 0x0000420C File Offset: 0x0000420C
		public object string_to_object(string json)
		{
			byte[] bytes = Encoding.Default.GetBytes(json);
			object result;
			using (MemoryStream memoryStream = new MemoryStream(bytes))
			{
				result = this.serializer.ReadObject(memoryStream);
			}
			return result;
		}

		// Token: 0x0600008E RID: 142 RVA: 0x00004258 File Offset: 0x00004258
		public T string_to_generic<T>(string json)
		{
			return (T)((object)this.string_to_object(json));
		}

		// Token: 0x04000037 RID: 55
		private DataContractJsonSerializer serializer;

		// Token: 0x04000038 RID: 56
		private object current_object;
	}
}
