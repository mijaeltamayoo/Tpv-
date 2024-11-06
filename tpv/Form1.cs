using System;
using System.Windows.Forms;

namespace tpv
{
    public partial class Form1 : Form
    {
        private Conexion conexion;

        public Form1()
        {
            InitializeComponent();
            conexion = new Conexion();
        }

        private void entrar_Click(object sender, EventArgs e)
        {
            string usuario = text_user.Text;   
            string password = text_password.Text;
            
            string tipo = conexion.VerificarUsuario(usuario, password);

            if (tipo != null)
            {
                if (tipo == "administrador")
                {
                    adminform adminForm = new adminform();
                    adminForm.Show();
                    
                }
                else if (tipo == "usuario")
                {
                    usuarioventas usuarioventas = new usuarioventas();
                    usuarioventas.Show();
                }
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos.");
            }
        }

        
    }
}
