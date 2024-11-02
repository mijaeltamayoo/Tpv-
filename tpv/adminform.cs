using System;
using System.Data;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace tpv
{
    public partial class adminform : Form
    {

        private Conexion conexion;
        private ImageList imageListProductos;
        private ImageList imageListCategorias; // Nueva ImageList para categorías

        public adminform()
        {
            InitializeComponent();
            conexion = new Conexion();
            imageListProductos = new ImageList();
            imageListCategorias = new ImageList(); // Inicializa la ImageList para categorías
            imageListCategorias.ImageSize = new Size(50, 40); // Ajusta el tamaño de la imagen
            listView1.LargeImageList = imageListCategorias; // Asocia la ImageList con listView1
            listView2.LargeImageList = imageListProductos; // Asocia la ImageList con listView2
            CargarCategorias();
        }

        private void CargarCategorias()
        {
            DataTable categorias = conexion.ObtenerCategorias();
            listView1.Items.Clear();
            imageListCategorias.Images.Clear(); // Limpia las imágenes previas

            foreach (DataRow row in categorias.Rows)
            {
                string nombreCategoria = row["nombre"].ToString();
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "categorias", row["imagen"].ToString());

                // Verifica si la imagen de la categoría existe
                if (File.Exists(imagePath))
                {
                    imageListCategorias.Images.Add(nombreCategoria, Image.FromFile(imagePath));
                }


                ListViewItem item = new ListViewItem(nombreCategoria)
                {
                    ImageKey = nombreCategoria, // Usa el nombre como clave para la imagen
                    Tag = row["id"].ToString() // Guarda el ID de la categoría en el Tag
                };

                listView1.Items.Add(item);
            }

            // Evento de selección de categoría
            listView1.SelectedIndexChanged += ListViewCategorias_SelectedIndexChanged;
        }

        private void ListViewCategorias_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                string categoriaId = listView1.SelectedItems[0].Tag.ToString();
                CargarProductosPorCategoria(categoriaId);
            }
        }

        private void CargarProductosPorCategoria(string categoriaId)
        {
            DataTable productos = conexion.ObtenerProductosPorCategoria(categoriaId);
            listView2.Items.Clear();
            imageListProductos.Images.Clear(); // Limpia las imágenes previas

            foreach (DataRow row in productos.Rows)
            {
                string nombreProducto = row["nombre"].ToString();
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "productos", row["imagen"].ToString()); // Ajustar ruta para productos

                Console.WriteLine($"Cargando imagen del producto: {imagePath}"); // Mensaje de depuración

                // Verificar si la imagen del producto existe
                if (File.Exists(imagePath))
                {
                    imageListProductos.Images.Add(nombreProducto, Image.FromFile(imagePath));
                }
                else
                {
                    MessageBox.Show($"Imagen no encontrada para el producto: {imagePath}"); // Mensaje de depuración
                    imageListProductos.Images.Add(nombreProducto, Properties.Resources.box2); // Imagen predeterminada para productos
                }

                ListViewItem item = new ListViewItem(nombreProducto)
                {
                    ImageKey = nombreProducto,
                    Tag = row
                };

                listView2.Items.Add(item);
            }
        }
    }
}
