using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

namespace VenomRAT_HVNC.StreamLibrary.src
{
    public class JpgCompression
    {
        public JpgCompression(int Quality)
        {
            this.parameter = new EncoderParameter(Encoder.Quality, (long)Quality);
            this.encoderInfo = this.GetEncoderInfo("image/jpeg");
            this.encoderParams = new EncoderParameters(2);
            this.encoderParams.Param[0] = this.parameter;
            this.encoderParams.Param[1] = new EncoderParameter(Encoder.Compression, 2L);
        }

        public byte[] Compress(Bitmap bmp)
        {
            byte[] result;
            using (MemoryStream memoryStream = new MemoryStream())
            {
                bmp.Save(memoryStream, this.encoderInfo, this.encoderParams);
                result = memoryStream.ToArray();
            }
            return result;
        }

        public void Compress(Bitmap bmp, ref Stream TargetStream)
        {
            bmp.Save(TargetStream, this.encoderInfo, this.encoderParams);
        }

        private ImageCodecInfo GetEncoderInfo(string mimeType)
        {
            ImageCodecInfo[] imageEncoders = ImageCodecInfo.GetImageEncoders();
            int num = imageEncoders.Length - 1;
            for (int i = 0; i <= num; i++)
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
