using ImageMagick;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ferreteria.Entidades
{
    public class ProductoVista
    {
        public int id { get; set; }
        public byte[] Imagen { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public string DescripcionLarga { get; set; }
        public string CodigoDeBarras { get; set; }
        public string Usuario { get; set; }
        public string Departamento { get; set; }
        public string Sucursal { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Propiedad adicional para convertir la imagen
        public Image Fotografia
        {
            get
            {
                if (Imagen == null || Imagen.Length == 0)
                    return Properties.Resources.LogoRecortado;

                if (IsWebPImage(Imagen))
                {
                    // Configuración para mejor rendimiento
                    var settings = new MagickReadSettings
                    {
                        Format = MagickFormat.WebP,
                        ColorSpace = ColorSpace.sRGB
                    };

                    using (var magickImage = new MagickImage(Imagen, settings))
                    {
                        // Convertir a MemoryStream en formato BMP
                        using (var memoryStream = new MemoryStream())
                        {
                            magickImage.Write(memoryStream, MagickFormat.Bmp);
                            memoryStream.Position = 0; // Rebobinar el stream
                            return new Bitmap(memoryStream);
                        }
                    }
                }
                else
                {
                    // Para formatos tradicionales
                    using (MemoryStream ms = new MemoryStream(Imagen))
                    {
                        return Image.FromStream(ms);
                    }
                }
            }
        }

        private bool IsWebPImage(byte[] imageData)
        {
            try
            {
                return imageData != null &&
                       imageData.Length > 12 &&
                       System.Text.Encoding.ASCII.GetString(imageData, 0, 4) == "RIFF" &&
                       System.Text.Encoding.ASCII.GetString(imageData, 8, 4) == "WEBP";
            }
            catch
            {
                return false;
            }
        }
        // Método privado para redimensionamiento
        private Image RedimensionarImagen(Image img, int maxWidth, int maxHeight)
        {
            double ratioX = (double)maxWidth / img.Width;
            double ratioY = (double)maxHeight / img.Height;
            double ratio = Math.Min(ratioX, ratioY);

            int newWidth = (int)(img.Width * ratio);
            int newHeight = (int)(img.Height * ratio);

            var nuevaImagen = new Bitmap(newWidth, newHeight);

            using (Graphics g = Graphics.FromImage(nuevaImagen))
            {
                g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                g.DrawImage(img, 0, 0, newWidth, newHeight);
            }

            return nuevaImagen;
        }
    }
}
