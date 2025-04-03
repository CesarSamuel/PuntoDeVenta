using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Ferreteria.Forms
{
    public partial class frmAddProducto : Form
    {
        public frmAddProducto()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Agregar producto");
        }

        private void btnExaminar_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "Imágenes (*.jpg; *.jpeg; *.png; *.bmp)|*.jpg; *.jpeg; *.png; *.bmp";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Verificar que el archivo es una imagen válida
                        using (var tempImage = Image.FromFile(openFileDialog.FileName))
                        {
                            // Si llegamos aquí, la imagen es válida
                            string rutaImagen = openFileDialog.FileName;
                            txtRutaImagen.Text = rutaImagen;
                            pbImagen.BackgroundImage = (Image)tempImage.Clone();
                            pbImagen.BackgroundImageLayout = ImageLayout.Stretch;

                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"El archivo seleccionado no es una imagen válida: {ex.Message}",
                                      "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
    }
}
