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


        public adminform()
        {
            InitializeComponent();
            conexion = new Conexion();
            CargarProductos();  // Cargar todos los productos inicialmente
            CargarCategorias();
            Limpiar();
        }

        private void CargarProductos()
        {
            // Cargar todos los productos (sin filtro)
            DataTable productos = conexion.ObtenerProductos();
            dataGridView2.DataSource = productos;

            // Configuración de las columnas
            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["imagen"].Visible = false;
            dataGridView2.Columns["nombre"].HeaderText = "Nombre";
            dataGridView2.Columns["precio"].HeaderText = "Precio";
            dataGridView2.Columns["stock"].HeaderText = "Stock";
            dataGridView2.Columns["categoria"].HeaderText = "Categoría";
            dataGridView2.Columns["precio"].DefaultCellStyle.Format = "C2";
            dataGridView2.Columns["precio"].DefaultCellStyle.FormatProvider = System.Globalization.CultureInfo.CreateSpecificCulture("es-ES");

            dataGridView2.ClearSelection();
        }


        private void CargarCategorias()
        {
            DataTable categorias = conexion.ObtenerCategorias();

            if (categorias.Rows.Count > 0)
            {
                comboBox1.DataSource = categorias.Copy();
                comboBox1.DisplayMember = "nombre";
                comboBox1.ValueMember = "id";

                comboBox2.DataSource = categorias;
                comboBox2.DisplayMember = "nombre";
                comboBox2.ValueMember = "id";
                comboBox2.SelectedIndex = -1;

            }
        }



        private void button2_Click(object sender, EventArgs e)
        {
            adminusuarios usuarios = new adminusuarios();
            usuarios.Show();
        }

        private void check_Click(object sender, EventArgs e)
        {
            string nombre = text_producto.Text;
            string precio = text_precio.Text;
            string stock = text_stock.Text;

            string categoria_id = comboBox1.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(categoria_id))
            {
                MessageBox.Show("Selecciona una categoría");
                return;
            }

            conexion.AgregarProductoaDB(nombre, precio, categoria_id, stock);
            CargarProductos();
        }

        private void dataGridView2_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridView2.Columns[e.ColumnIndex].Name == "stock")
            {
                if (e.Value != null && int.TryParse(e.Value.ToString(), out int stockValue))
                {
                    if (stockValue < 0)
                    {
                        e.Value = ""; 
                        e.FormattingApplied = true;
                    }
                }
            }
        }


        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                text_producto.Text = dataGridView2.CurrentRow.Cells["nombre"].Value.ToString();
                text_precio.Text = dataGridView2.CurrentRow.Cells["precio"].Value.ToString();
                text_stock.Text = dataGridView2.CurrentRow.Cells["stock"].Value.ToString();

            }


        }
        private void cross_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow != null)
            {
                string producto = dataGridView2.CurrentRow.Cells["nombre"].Value.ToString();
                DialogResult result = MessageBox.Show($"¿Estás seguro de que deseas eliminar al usuario '{producto}'?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int idproducto = (int)dataGridView2.CurrentRow.Cells["id"].Value;

                    conexion.EliminarUsuario(idproducto);
                    MessageBox.Show("Usuario eliminado.");
                    CargarProductos();
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView2.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un producto para editar.");
                return;
            }

            var result = MessageBox.Show("¿Quieres editar este producto?", "Confirmar edición", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                string producto = text_producto.Text;
                string precio = text_precio.Text;
                string stock = text_stock.Text;
                string categoria_id = null;

                var selectedItem = comboBox1.SelectedItem as DataRowView; // Cambié a DataRowView
                if (selectedItem != null)
                {
                    categoria_id = selectedItem["id"].ToString();  
                }

                if (string.IsNullOrEmpty(producto))
                {
                    MessageBox.Show("Ingresa el nombre del producto.");
                    return;
                }

                if (string.IsNullOrEmpty(precio))
                {
                    MessageBox.Show("Ingresa el precio del producto.");
                    return;
                }

                if (string.IsNullOrEmpty(stock))
                {
                    MessageBox.Show("Ingresa el stock del producto.");
                    return;
                }

                if (string.IsNullOrEmpty(categoria_id))
                {
                    MessageBox.Show("Selecciona una categoría.");
                    return;
                }

                int id_producto;
                if (int.TryParse(dataGridView2.CurrentRow.Cells["id"].Value.ToString(), out id_producto))
                {
                    conexion.ActualizarProducto(id_producto, producto, precio, stock, categoria_id);

                    MessageBox.Show("El producto se ha actualizado");
                }

                CargarProductos();
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string categoriaId = comboBox2.SelectedValue?.ToString();

            if (!string.IsNullOrEmpty(categoriaId))
            {
                // Filtrar los productos por la categoría seleccionada
                DataTable productosFiltrados = conexion.ObtenerProductosPorCategoria(categoriaId);
                dataGridView2.DataSource = productosFiltrados;
            }
            else
            {
                // Si no se selecciona categoría, cargar todos los productos
                CargarProductos(); // Muestra todos los productos
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            // Cuando se hace clic en PictureBox2, eliminar el filtro y mostrar todos los productos
            comboBox2.SelectedIndex = -1; // Desmarcar la categoría seleccionada
            CargarProductos(); // Mostrar todos los productos
        }

        private void Limpiar()
        {
            text_producto.Clear();  
            text_precio.Clear();    
            text_stock.Clear();     
        }

        
    }
}
