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
        }
        private void CargarProductos()
        {
            DataTable productos = conexion.ObtenerProductos();
            dataGridView2.DataSource = productos;

            dataGridView2.Columns["id"].Visible = false;
            dataGridView2.Columns["nombre"].HeaderText = "Nombre";
            dataGridView2.Columns["precio"].HeaderText = "Precio";
            dataGridView2.Columns["stock"].HeaderText = "Stock";
            dataGridView2.Columns["categoria_id"].Visible = false;
            dataGridView2.Columns["imagen"].Visible = false;
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
    }
}
