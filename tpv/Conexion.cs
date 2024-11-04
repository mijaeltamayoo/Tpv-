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
            string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "database_tpv.accdb");
            con = new OleDbConnection($"Provider=Microsoft.ACE.OLEDB.16.0; Data Source={ruta};");

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
            DataTable productos = new DataTable();

            try
            {
                AbrirConexion();
                string query = "SELECT * FROM productos";

                using (OleDbCommand command = new OleDbCommand(query, con))
                {
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        productos.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return productos;
        }


        public DataTable ObtenerCategorias()
        {
            DataTable categorias = new DataTable();

            try
            {
                AbrirConexion();

                // query para obtener las categorías
                string query = "SELECT * FROM categorias";

                //OleDbCommand nos permite ejecutar la query
                using (OleDbCommand command = new OleDbCommand(query, con))
                {
                    //OleDbDataReader permite leer los datos 
                    using (OleDbDataReader reader = command.ExecuteReader())
                    {
                        //carga los datos en la tabla categorias
                        categorias.Load(reader);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

            return categorias;
        }



        public DataTable ObtenerProductosPorCategoria(string categoriaId)
        {
            DataTable productos = new DataTable();

            //query para obtener el producto en donde la categoria_id sea igual a la categoria por parametro
            string query = "SELECT id, nombre, precio, stock, categoria_id, imagen FROM Productos WHERE categoria_id = @categoriaId";

            //OleDbCommand nos permite ejecutar la query
            using (OleDbCommand command = new OleDbCommand(query, con))
            {
                //Esta linea nos permite que se asocie la variable pasada en la funcion con la de la base de datos
                command.Parameters.AddWithValue("@categoriaId", categoriaId);

                AbrirConexion();

                //OleDbDataReader permite leer los datos 
                using (OleDbDataReader reader = command.ExecuteReader())
                {
                    //carga los datos en la tabla productos
                    productos.Load(reader);
                }
            }

            return productos;
        }




    }
}
