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
        }

        public void CargarRoles()
        {
            DataTable roles = conexion.ObtenerRoles();

            foreach (DataRow row in roles.Rows)
            {
                // Agrega el rol directamente a la lista del comboBox
                comboBox1.Items.Add(new { Id = row["Id"], Nombre = row["nombre"].ToString() });
            }

            comboBox1.DisplayMember = "Nombre";
            comboBox1.ValueMember = "Id";
        }


        private void crear_usuario_Click(object sender, EventArgs e)
        {
            string usuario = text_usuario.Text;
            string password = text_contraseña.Text;
            string id_rol = null;

            // Asegúrate de que el SelectedItem no sea nulo y está usando el objeto correcto
            var selectedItem = comboBox1.SelectedItem as dynamic; // Usar dynamic para acceder a las propiedades

            if (selectedItem != null)
            {
                id_rol = selectedItem.Id.ToString(); // Acceder a la propiedad Id
            }

            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Ingresa el nombre o contraseña");
                return;
            }

            if (string.IsNullOrEmpty(id_rol))
            {
                MessageBox.Show("Debes seleccionar un rol.");
                return;
            }

            // Llamar a la función para agregar el usuario
            conexion.AgregarUsuarioDB(usuario, password, id_rol);
        }



    }
}
