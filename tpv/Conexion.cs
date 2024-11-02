using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace tpv
{
    internal class Conexion
    {
        public OleDbConnection con { get; set; }

        public Conexion()
        {
            //12
            con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=C:\\Users\\2dam3\\source\\repos\\Tpv-\\tpv\\database\\database_tpv.accdb;");
        }

        public void AbrirConexion()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
        }

        public string VerificarUsuario(string usuario, string password)
        {
            string tipo = null;

            try
            {
                AbrirConexion();
                string query = "SELECT r.nombre FROM usuarios u " +
                               "INNER JOIN roles r ON u.id_rol = r.id " +
                               "WHERE u.usuario = @usuario AND u.password = @password";

                using (OleDbCommand command = new OleDbCommand(query, con))
                {
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@password", password);

                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            tipo = reader["nombre"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }


            return tipo;
        }

        public DataTable ObtenerProductos()
        {
            DataTable dt = new DataTable();

            try
            {
                AbrirConexion();
                string query = "SELECT * FROM productos"; 

                using (OleDbDataAdapter da = new OleDbDataAdapter(query, con))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return dt;
        }


        public DataTable ObtenerCategorias()
        {
            DataTable dt = new DataTable();

            try
            {
                AbrirConexion();
                string query = "SELECT id, nombre, imagen FROM categorias";

                using (OleDbDataAdapter da = new OleDbDataAdapter(query, con))
                {
                    da.Fill(dt);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return dt;
        }



    }
}
