using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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

        
    }
}
