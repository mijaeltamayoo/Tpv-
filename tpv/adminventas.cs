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
    public partial class adminventas : Form
    {
        private Conexion conexion;
        private ImageList imageListProductos;
        private ImageList imageListCategorias; // Nueva ImageList para categorías

        public adminventas()
        {
            InitializeComponent();
            conexion = new Conexion();
            imageListProductos = new ImageList();
            imageListCategorias = new ImageList(); // Inicializa la ImageList para categorías
            imageListCategorias.ImageSize = new Size(50, 40); // Ajusta el tamaño de la imagen
            imageListProductos.ImageSize = new Size(90, 50);
            listView1.LargeImageList = imageListCategorias; // Asocia la ImageList con listView1
            listView2.LargeImageList = imageListProductos; // Asocia la ImageList con listView2
            CargarCategorias();

            CargarTabla();

            listView2.SelectedIndexChanged += ListViewProductos_SelectedIndexChanged;
            dataGridView1.CellEndEdit += dataGridViewProductos_CellEndEdit;

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

                listView1.Items.Add(new ListViewItem(nombreCategoria, nombreCategoria) { Tag = row["id"].ToString() });
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

            // Obtener el nombre de la categoría basado en el ID seleccionado
            string nombreCategoria = listView1.SelectedItems[0].Text;

            foreach (DataRow row in productos.Rows)
            {
                string nombreProducto = row["nombre"].ToString();

                // Construir la ruta usando el nombre de la categoría como subcarpeta
                string imagePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "productos", nombreCategoria, row["imagen"].ToString());

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

        private void CargarTabla()
        {
            // Agrega columnas al DataGridView
            dataGridView1.Columns.Add("Articulo", "Artículo");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("Cantidad", "Cant.");
            dataGridView1.Columns.Add("Impuestos", "Impuestos");
            dataGridView1.Columns.Add("Importe", "Importe");

            // Configura el ancho de las columnas y el formato de celda
            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "C2"; // Formato de moneda
            dataGridView1.Columns["Importe"].DefaultCellStyle.Format = "C2"; // Formato de moneda
        }

        private void ListViewProductos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                DataRow producto = (DataRow)listView2.SelectedItems[0].Tag;
                string nombreProducto = producto["nombre"].ToString();
                decimal precio = Convert.ToDecimal(producto["precio"]);

                // Mostrar el nombre y el precio en los TextBox correspondientes
                text_producto.Text = nombreProducto;
                text_precio.Text = precio.ToString("C2"); // Formato de moneda
                text_cantidad.Text = "1"; // Valor inicial para la cantidad
            }
        }


        private void dataGridViewProductos_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dataGridView1.Columns["Cantidad"].Index)
            {
                // Obtener datos de la fila editada
                int cantidad = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells["Cantidad"].Value);
                decimal precio = Convert.ToDecimal(dataGridView1.Rows[e.RowIndex].Cells["Precio"].Value);
                decimal importe = precio * cantidad;

                // Actualizar el importe
                dataGridView1.Rows[e.RowIndex].Cells["Importe"].Value = importe;
            }
        }

        private void check_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_producto.Text) &&
        !string.IsNullOrEmpty(text_precio.Text) &&
        !string.IsNullOrEmpty(text_cantidad.Text) &&
        int.TryParse(text_cantidad.Text, out int cantidad))
            {
                string nombreProducto = text_producto.Text;
                decimal precio = decimal.Parse(text_precio.Text, System.Globalization.NumberStyles.Currency);
                decimal impuestos = 0; // Porcentaje de impuestos (puedes ajustarlo según tu lógica)
                decimal importe = precio * cantidad;

                // Agregar el producto al DataGridView
                dataGridView1.Rows.Add(nombreProducto, precio, cantidad, $"{impuestos}%", importe);

                // Limpiar los TextBox después de agregar el producto
                text_producto.Clear();
                text_precio.Clear();
                text_cantidad.Clear();
            }
            else
            {
                MessageBox.Show("Por favor, ingrese una cantidad válida.");
            }
        }
    }
}
