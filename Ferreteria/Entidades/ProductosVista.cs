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
        public byte[] Imagen { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Stock { get; set; }

        // Propiedad adicional para convertir la imagen
        public Image Fotografia
        {
            get
            {
                if (Imagen == null || Imagen.Length == 0)
                    return Properties.Resources.LogoRecortado;

                using (MemoryStream ms = new MemoryStream(Imagen))
                {
                    var img = Image.FromStream(ms);
                    return RedimensionarImagen(img, 120, 120); // Tamaño deseado
                }
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
