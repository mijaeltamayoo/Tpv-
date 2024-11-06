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
            DataTable usuariosConRoles = conexion.ObtenerUsuarios();
            dataGridView1.DataSource = usuariosConRoles;

            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["usuario"].HeaderText = "Usuario";
            dataGridView1.Columns["password"].HeaderText = "Contraseña";
            dataGridView1.Columns["rol"].HeaderText = "Rol";
        }



        private void button1_Click(object sender, EventArgs e)
        {
            adminform adminform = new adminform();
            adminform.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            adminventas adminventas = new adminventas();
            adminventas.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void btn_add_Click(object sender, EventArgs e)
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

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                text_usuario.Text = dataGridView1.CurrentRow.Cells["usuario"].Value.ToString();
                text_contraseña.Text = dataGridView1.CurrentRow.Cells["password"].Value.ToString();
                comboBox1.SelectedValue = dataGridView1.CurrentRow.Cells["rol"].Value.ToString(); 
            }
        }

        private void cross_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                string producto = dataGridView1.CurrentRow.Cells["Articulo"].Value.ToString();
                DialogResult result = MessageBox.Show($"¿Estás seguro de que deseas eliminar este producto '{producto}'?",
                                                      "Confirmar eliminación",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    dataGridView1.Rows.Remove(dataGridView1.CurrentRow);

                }
            }
        }


        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecciona un usuario para editar.");
                return;
            }

            var result = MessageBox.Show("¿Estás seguro de que deseas editar este usuario?", "Confirmar edición", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
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

                int idUsuario;
                if (int.TryParse(dataGridView1.CurrentRow.Cells["id"].Value.ToString(), out idUsuario))
                {
                    conexion.EditarUsuario(idUsuario, usuario, password, id_rol);
                }
                else
                {
                    MessageBox.Show("El ID del usuario no es válido.");
                    return;
                }

                CargarUsuarios();
            }
        }

    }
}
