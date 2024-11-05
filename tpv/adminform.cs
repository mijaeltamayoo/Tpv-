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
            CargarProductos();
            CargarCategorias();
        }

        private void CargarProductos()
        {
            DataTable productos = conexion.ObtenerProductos();
            dataGridView2.DataSource = productos;

            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["nombre"].HeaderText = "Nombre";
            dataGridView2.Columns["precio"].HeaderText = "Precio";
            dataGridView2.Columns["stock"].HeaderText = "Stock";
            dataGridView2.Columns["categoria"].HeaderText = "Categoría"; 
            dataGridView2.Columns["imagen"].HeaderText = "Nombre de imagen";
        }
        private void CargarCategorias()
        {
            DataTable categorias = conexion.ObtenerCategorias();

            if (categorias.Rows.Count > 0)
            {
                comboBox1.DataSource = categorias;
                comboBox1.DisplayMember = "nombre"; 
                comboBox1.ValueMember = "id"; 
            }
            else
            {
                MessageBox.Show("No se encontraron categorías.");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminventas ventas = new adminventas();
            ventas.Show();
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
            string imagen = text_imagen.Text;

            // Obtén el valor de la categoría seleccionada
            string categoria_id = comboBox1.SelectedValue?.ToString();

            if (string.IsNullOrEmpty(categoria_id))
            {
                MessageBox.Show("Selecciona una categoría");
                return;
            }

            conexion.AgregarProductoaDB(nombre, precio, categoria_id, stock, imagen);
        }

    }
}
