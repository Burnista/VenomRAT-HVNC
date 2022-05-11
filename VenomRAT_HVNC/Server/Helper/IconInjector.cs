using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security;

namespace VenomRAT_HVNC.Server.Helper
{
    public static class IconInjector
    {
        [SuppressUnmanagedCodeSecurity]
        private class NativeMethods
        {
            [DllImport("kernel32")]
            public static extern IntPtr BeginUpdateResource(string fileName, [MarshalAs(UnmanagedType.Bool)] bool deleteExistingResources);

            [DllImport("kernel32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool UpdateResource(IntPtr hUpdate, IntPtr type, IntPtr name, short language, [MarshalAs(UnmanagedType.LPArray, SizeParamIndex = 5)] byte[] data, int dataSize);

            [DllImport("kernel32")]
            [return: MarshalAs(UnmanagedType.Bool)]
            public static extern bool EndUpdateResource(IntPtr hUpdate, [MarshalAs(UnmanagedType.Bool)] bool discard);
        }

        private struct ICONDIR
        {
            public ushort Reserved;

            public ushort Type;

            public ushort Count;
        }

        private struct ICONDIRENTRY
        {
            public byte Width;

            public byte Height;

            public byte ColorCount;

            public byte Reserved;

            public ushort Planes;

            public ushort BitCount;

            public int BytesInRes;

            public int ImageOffset;
        }

        private struct BITMAPINFOHEADER
        {
            public uint Size;

            public int Width;

            public int Height;

            public ushort Planes;

            public ushort BitCount;

            public uint Compression;

            public uint SizeImage;

            public int XPelsPerMeter;

            public int YPelsPerMeter;

            public uint ClrUsed;

            public uint ClrImportant;
        }

        [StructLayout(LayoutKind.Sequential, Pack = 2)]
        private struct GRPICONDIRENTRY
        {
            public byte Width;

            public byte Height;

            public byte ColorCount;

            public byte Reserved;

            public ushort Planes;

            public ushort BitCount;

            public int BytesInRes;

            public ushort ID;
        }

        private class IconFile
        {
            private ICONDIR iconDir;

            private ICONDIRENTRY[] iconEntry;

            private byte[][] iconImage;

            public int ImageCount => iconDir.Count;

            public byte[] ImageData(int index)
            {
                return iconImage[index];
            }

            public static IconFile FromFile(string filename)
            {
                IconFile iconFile = new IconFile();
                byte[] array = File.ReadAllBytes(filename);
                GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                iconFile.iconDir = (ICONDIR)Marshal.PtrToStructure(gCHandle.AddrOfPinnedObject(), typeof(ICONDIR));
                iconFile.iconEntry = new ICONDIRENTRY[iconFile.iconDir.Count];
                iconFile.iconImage = new byte[iconFile.iconDir.Count][];
                int num = Marshal.SizeOf(iconFile.iconDir);
                Type typeFromHandle = typeof(ICONDIRENTRY);
                int num2 = Marshal.SizeOf(typeFromHandle);
                for (int i = 0; i <= iconFile.iconDir.Count - 1; i++)
                {
                    ICONDIRENTRY iCONDIRENTRY = (ICONDIRENTRY)Marshal.PtrToStructure(new IntPtr(gCHandle.AddrOfPinnedObject().ToInt64() + num), typeFromHandle);
                    iconFile.iconEntry[i] = iCONDIRENTRY;
                    iconFile.iconImage[i] = new byte[iCONDIRENTRY.BytesInRes];
                    Buffer.BlockCopy(array, iCONDIRENTRY.ImageOffset, iconFile.iconImage[i], 0, iCONDIRENTRY.BytesInRes);
                    num += num2;
                }
                gCHandle.Free();
                return iconFile;
            }

            public byte[] CreateIconGroupData(uint iconBaseID)
            {
                int num = Marshal.SizeOf(typeof(ICONDIR)) + Marshal.SizeOf(typeof(GRPICONDIRENTRY)) * ImageCount;
                byte[] array = new byte[num];
                GCHandle gCHandle = GCHandle.Alloc(array, GCHandleType.Pinned);
                Marshal.StructureToPtr(iconDir, gCHandle.AddrOfPinnedObject(), fDeleteOld: false);
                int num2 = Marshal.SizeOf(iconDir);
                for (int i = 0; i <= ImageCount - 1; i++)
                {
                    GRPICONDIRENTRY structure = default(GRPICONDIRENTRY);
                    BITMAPINFOHEADER bITMAPINFOHEADER = default(BITMAPINFOHEADER);
                    GCHandle gCHandle2 = GCHandle.Alloc(bITMAPINFOHEADER, GCHandleType.Pinned);
                    Marshal.Copy(ImageData(i), 0, gCHandle2.AddrOfPinnedObject(), Marshal.SizeOf(typeof(BITMAPINFOHEADER)));
                    gCHandle2.Free();
                    structure.Width = iconEntry[i].Width;
                    structure.Height = iconEntry[i].Height;
                    structure.ColorCount = iconEntry[i].ColorCount;
                    structure.Reserved = iconEntry[i].Reserved;
                    structure.Planes = bITMAPINFOHEADER.Planes;
                    structure.BitCount = bITMAPINFOHEADER.BitCount;
                    structure.BytesInRes = iconEntry[i].BytesInRes;
                    structure.ID = Convert.ToUInt16(iconBaseID + i);
                    Marshal.StructureToPtr(structure, new IntPtr(gCHandle.AddrOfPinnedObject().ToInt64() + num2), fDeleteOld: false);
                    num2 += Marshal.SizeOf(typeof(GRPICONDIRENTRY));
                }
                gCHandle.Free();
                return array;
            }
        }

        public static void InjectIcon(string exeFileName, string iconFileName)
        {
            InjectIcon(exeFileName, iconFileName, 1u, 1u);
        }

        public static void InjectIcon(string exeFileName, string iconFileName, uint iconGroupID, uint iconBaseID)
        {
            IconFile iconFile = IconFile.FromFile(iconFileName);
            IntPtr hUpdate = NativeMethods.BeginUpdateResource(exeFileName, deleteExistingResources: false);
            byte[] array = iconFile.CreateIconGroupData(iconBaseID);
            NativeMethods.UpdateResource(hUpdate, new IntPtr(14L), new IntPtr(iconGroupID), 0, array, array.Length);
            for (int i = 0; i <= iconFile.ImageCount - 1; i++)
            {
                byte[] array2 = iconFile.ImageData(i);
                NativeMethods.UpdateResource(hUpdate, new IntPtr(3L), new IntPtr(iconBaseID + i), 0, array2, array2.Length);
            }
            NativeMethods.EndUpdateResource(hUpdate, discard: false);
        }
    }
}