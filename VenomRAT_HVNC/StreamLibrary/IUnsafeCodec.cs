using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using VenomRAT_HVNC.StreamLibrary.src;

namespace VenomRAT_HVNC.StreamLibrary
{
    public abstract class IUnsafeCodec
    {
        protected JpgCompression jpgCompression;

        protected LzwCompression lzwCompression;

        private int _imageQuality;

        public abstract ulong CachedSize { get; internal set; }

        protected object ImageProcessLock { get; private set; }

        public int ImageQuality
        {
            get
            {
                return _imageQuality;
            }
            set
            {
                _imageQuality = value;
                jpgCompression = new JpgCompression(value);
                lzwCompression = new LzwCompression(value);
            }
        }

        public abstract int BufferCount { get; }

        public abstract CodecOption CodecOptions { get; }

        public abstract event IVideoCodec.VideoDebugScanningDelegate onCodeDebugScan;

        public abstract event IVideoCodec.VideoDebugScanningDelegate onDecodeDebugScan;

        public IUnsafeCodec(int ImageQuality = 100)
        {
            this.ImageQuality = ImageQuality;
            ImageProcessLock = new object();
        }

        public abstract void CodeImage(IntPtr Scan0, Rectangle ScanArea, Size ImageSize, PixelFormat Format, Stream outStream);

        public abstract Bitmap DecodeData(Stream inStream);

        public abstract Bitmap DecodeData(IntPtr CodecBuffer, uint Length);
    }
}