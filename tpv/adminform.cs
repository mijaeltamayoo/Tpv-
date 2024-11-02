using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tpv
{
    public partial class adminform : Form
    {
        private Conexion conexion;
        public adminform()
        {
            InitializeComponent();
            conexion = new Conexion();
            CargarProductos();
            CargarCategorias();
        }

        private void CargarProductos()
        {
            DataTable productos = conexion.ObtenerProductos();
            dataGridView2.DataSource = productos; // Asignar el DataTable al DataGridView

            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["nombre"].Visible = true;
            dataGridView2.Columns["precio"].Visible = true;
            dataGridView2.Columns["stock"].Visible = true;
            dataGridView2.Columns["categoria_id"].Visible = false;
            dataGridView2.Columns["imagen"].Visible = false;

        }

        private void CargarCategorias()
        {
            DataTable categorias = conexion.ObtenerCategorias(); // Obtener las categorías desde la base de datos

            listView1.Items.Clear();
            ImageList imageList = new ImageList();
            imageList.ImageSize = new Size(100, 100); // Ajusta el tamaño según lo necesites
            listView1.LargeImageList = imageList;

            // Obtener la ruta de la carpeta de imágenes desde la base de datos de la aplicación
            string basePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "categorias");

            foreach (DataRow row in categorias.Rows)
            {
                string nombre = row["nombre"].ToString();
                string rutaImagen = Path.Combine(basePath, row["imagen"].ToString());

                // Imprimir en la consola o mostrar en un MessageBox para depuración
                Console.WriteLine($"Buscando imagen en: {rutaImagen}"); // O usa MessageBox para verificar
                if (File.Exists(rutaImagen))
                {
                    imageList.Images.Add(row["imagen"].ToString(), Image.FromFile(rutaImagen));

                    ListViewItem item = new ListViewItem(nombre)
                    {
                        ImageKey = row["imagen"].ToString() // Usar el nombre del archivo como clave de imagen
                    };

                    listView1.Items.Add(item);
                }
                else
                {
                    MessageBox.Show($"No se encontró la imagen: {rutaImagen}");
                }
            }
        }





    }
}
