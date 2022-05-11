using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VenomRAT_HVNC.StreamLibrary.src
{
    public class LzwCompression
    {
        public LzwCompression(int Quality)
        {
            this.parameter = new EncoderParameter(Encoder.Quality, (long)Quality);
            this.encoderInfo = this.GetEncoderInfo("image/jpeg");
            this.encoderParams = new EncoderParameters(2);
            this.encoderParams.Param[0] = this.parameter;
            this.encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 2L);
        }

        public byte[] Compress(Bitmap bmp, byte[] AdditionInfo = null)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                if (AdditionInfo != null)
                {
                    memoryStream.Write(AdditionInfo, 0, AdditionInfo.Length);
                }
                bmp.Save(memoryStream, this.encoderInfo, this.encoderParams);
                result = memoryStream.ToArray();
            }
            return result;
        }

        public void Compress(Bitmap bmp, Stream stream, byte[] AdditionInfo = null)
        {
            if (AdditionInfo != null)
            {
                stream.Write(AdditionInfo, 0, AdditionInfo.Length);
            }
            bmp.Save(stream, this.encoderInfo, this.encoderParams);
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            for (int i = 0; i < imageEncoders.Length; i++)
            {
                if (imageEncoders[i].MimeType == mimeType)
                {
                    return imageEncoders[i];
                }
            }
            return null;
        }

        private EncoderParameter parameter;

        private ImageCodecInfo encoderInfo;

        private EncoderParameters encoderParams;
    }
}
