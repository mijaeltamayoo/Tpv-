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
    public partial class adminusuarios : Form
    {
        private Conexion conexion;
        public adminusuarios()
        {
            InitializeComponent();
            conexion = new Conexion();

            CargarRoles();
            CargarUsuarios();
        }

        public void CargarRoles()
        {
            DataTable roles = conexion.ObtenerRoles();

            foreach (DataRow row in roles.Rows)
            {
                comboBox1.Items.Add(new { Id = row["Id"], Nombre = row["nombre"].ToString() });
            }

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
        }

        private void CargarUsuarios()
        {
            DataTable usuariosConRoles = conexion.ObtenerUsuariosConRoles();
            dataGridView1.DataSource = usuariosConRoles;

            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["usuario"].HeaderText = "Usuario";
            dataGridView1.Columns["password"].HeaderText = "Contraseña";
            dataGridView1.Columns["rol"].HeaderText = "Rol";
        }

        private void crear_usuario_Click(object sender, EventArgs e)
        {
            string usuario = text_usuario.Text;
            string password = text_contraseña.Text;
            string id_rol = null;

            var selectedItem = comboBox1.SelectedItem as dynamic; 

            if (selectedItem != null)
            {
                id_rol = selectedItem.Id.ToString(); 
            }

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingresa el nombre o contraseña");
                return;
            }

            if (string.IsNullOrEmpty(id_rol))
            {
                MessageBox.Show("Selecciona un rol");
                return;
            }

            conexion.AgregarUsuarioDB(usuario, password, id_rol);
        }


    }
}
