using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
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
            string basePath = AppDomain.CurrentDomain.BaseDirectory; // Obtiene la ruta base del proyecto
            string relativePath = Path.Combine(basePath, "database", "database_tpv.accdb"); // Ruta relativa a la base de datos
            con = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.16.0; Data Source={relativePath};");
            //12
            //C:\Users\mijae\Source\Repos\Tpv-\tpv\database\
            //con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.16.0; Data Source=C:\\Users\\2dam3\\source\\repos\\Tpv-\\tpv\\database\\database_tpv.accdb;");
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

        public DataTable ObtenerProductosPorCategoria(string categoriaId)
        {
            // Método para obtener productos por categoría
            DataTable productos = new DataTable();
            string query = "SELECT id, nombre, precio, stock, categoria_id, imagen FROM Productos WHERE categoria_id = @categoriaId";

            using (OleDbCommand command = new OleDbCommand(query, con))
            {
                command.Parameters.AddWithValue("@categoriaId", categoriaId);

                using (OleDbDataAdapter adapter = new OleDbDataAdapter(command))
                {
                    adapter.Fill(productos);
                }
            }

            return productos;
        }




    }
}
