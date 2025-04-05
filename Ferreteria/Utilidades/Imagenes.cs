using ImageMagick;
using System.Drawing;
using System.IO;
using System.Text;

namespace Ferreteria.Utilidades
{
    public class Imagenes
    {

        public Image ByteArrayToImage(byte[] byteArray)
        {
            // Verificar si es WebP (por los primeros bytes)
            if (IsWebPImage(byteArray))
            {
                using (var magickImage = new MagickImage(byteArray))
                {
                    // Convertir a formato compatible con Windows Forms
                    using (var ms = new MemoryStream())
                    {
                        magickImage.Write(ms, MagickFormat.Bmp);
                        ms.Position = 0;
                        return new Bitmap(ms);
                    }
                }
            }
            else
            {
                // Para formatos tradicionales (JPG, PNG, etc.)
                using (var ms = new MemoryStream(byteArray))
                {
                    return new Bitmap(ms);
                }
            }
        }

        private bool IsWebPImage(byte[] imageData)
        {
            try
            {
                return imageData.Length > 12 &&
                       Encoding.ASCII.GetString(imageData, 0, 4) == "RIFF" &&
                       Encoding.ASCII.GetString(imageData, 8, 4) == "WEBP";
            }
            catch
            {
                return false;
            }
        }
    }
}
