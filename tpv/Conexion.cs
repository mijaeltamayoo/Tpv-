using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Security.Cryptography;
using System.Windows.Forms;

namespace tpv
{
    internal class Conexion
    {
        public OleDbConnection con { get; set; }

        public Conexion()
        {
            //string ruta = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "database", "database_tpv.accdb");
            string ruta = @"C:\Users\2dam3\source\repos\Tpv-\tpv\database\database_tpv.accdb";

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

 
        public DataTable ObtenerRoles()
        {
            DataTable roles = new DataTable();
            AbrirConexion();
            string query = "SELECT * FROM roles";

            using (OleDbCommand cmd = new OleDbCommand(query, con))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
                adapter.Fill(roles);
            }
            return roles;
        }

        public DataTable ObtenerUsuarios()
        {
            DataTable usuariosConRoles = new DataTable();
            AbrirConexion();

            string query = @"
            SELECT u.id, u.usuario, u.password, r.nombre AS rol
            FROM usuarios u
            INNER JOIN roles r ON u.id_rol = r.id";

            using (OleDbCommand command = new OleDbCommand(query, con))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                adapter.Fill(usuariosConRoles);
            }

            return usuariosConRoles;
        }

        public void AgregarUsuarioDB(string usuario, string password, string id_rol)
        {

            if (ExisteUsuario(usuario))
            {
                MessageBox.Show("El nombre del usuario ya existe");
                return;
            }

            AbrirConexion();
            string query = "INSERT INTO [usuarios] ([usuario], [password], [id_rol]) VALUES (@usuario, @password, @id_rol)";

            using (OleDbCommand command = new OleDbCommand(query, con))
            {
                command.Parameters.AddWithValue("@usuario", usuario);
                command.Parameters.AddWithValue("@password", password);
                command.Parameters.AddWithValue("@id_rol", int.Parse(id_rol)); 

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("El usuario se ha creado");
                }
            }
      
        }
        public void EliminarUsuario(int id)
        {
            AbrirConexion();
            string query = "DELETE FROM usuarios WHERE id = @id";

            using (OleDbCommand command = new OleDbCommand(query, con))
            {
                command.Parameters.AddWithValue("@idUsuario", id);
                command.ExecuteNonQuery();
            }
        }

        public void EditarUsuario(int idUsuario, string usuario, string password, string idRol)
        {
            try
            {
                AbrirConexion();
                string query = "UPDATE [usuarios] SET [usuario] = @usuario, [password] = @password, [id_rol] = @id_rol WHERE [id] = @id";
                using (OleDbCommand command = new OleDbCommand(query, con))
                {
                    command.Parameters.AddWithValue("@usuario", usuario);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@id_rol", int.Parse(idRol));
                    command.Parameters.AddWithValue("@idUsuario", idUsuario);

                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        MessageBox.Show("Usuario actualizado.");
                    }
                    else
                    {
                        MessageBox.Show("No se pudo actualizar el usuario.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public bool ExisteUsuario(string usuario)
        {
            bool found = false;

            AbrirConexion();
            string query = "SELECT COUNT(*) FROM usuarios WHERE usuario = ?"; 

            using (OleDbCommand command = new OleDbCommand(query, con))
            {
                command.Parameters.AddWithValue("?", usuario);

                int count = (int)command.ExecuteScalar();
                found = (count > 0);
            }


            return found;
        }

        public DataTable ObtenerProductos()
        {
            DataTable productos = new DataTable();

            try
            {
                AbrirConexion();
                string query = @"SELECT p.id, p.nombre, p.precio, p.stock, c.nombre AS categoria, p.imagen
                         FROM productos p
                         INNER JOIN categorias c ON p.categoria_id = c.id";

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

        public void AgregarProductoaDB(string nombre, string precio, string categoria_id,string stock)
        {
            AbrirConexion();
            string query = "INSERT INTO productos (nombre, precio, categoria_id, stock) values (@nombre, @precio,@caetgoria_id, @stock)";
            using (OleDbCommand command = new OleDbCommand(@query, con))
            {
                command.Parameters.AddWithValue("@nombre", nombre);
                command.Parameters.AddWithValue("@precio", precio);
                command.Parameters.AddWithValue("@categoria_id", categoria_id);
                command.Parameters.AddWithValue("@stock", stock);

                int result = command.ExecuteNonQuery();
                if (result > 0)
                {
                    MessageBox.Show("El usuario se ha creado");
                }

            }
        }

        public void EliminarProducto(int id)
        {
            AbrirConexion();
            string query = "DELETE FROM productos WHERE id = @id";

            using (OleDbCommand command = new OleDbCommand(query, con))
            {
                command.Parameters.AddWithValue("@idproducto", id);
                command.ExecuteNonQuery();
            }
        }

        public void ActualizarProducto(int id_producto, string nuevoNombre, string nuevoPrecio, string nuevoStock, string nuevaCategoriaId)
        {
            try
            {
                AbrirConexion();
                string query = "UPDATE [productos] SET [nombre] = @nombre, [precio] = @precio, [categoria_id] = @categoria_id, [stock] = @stock WHERE [id] = @id";
                using (OleDbCommand command = new OleDbCommand(query, con))
                {
                    command.Parameters.AddWithValue("@nombre", nuevoNombre);
                    command.Parameters.AddWithValue("@precio", nuevoPrecio);
                    command.Parameters.AddWithValue("@categoria_id", nuevaCategoriaId);
                    command.Parameters.AddWithValue("@stock", nuevoStock);
                    command.Parameters.AddWithValue("@id", id_producto);
                    command.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public DataTable ObtenerProductosConCategoriaID()
        {
            DataTable productos_categoria = new DataTable();
            AbrirConexion();

            string query = @"
            SELECT p.id, p.nombre, p.precio, p.stock, c.categoria_id AS categoria , p.imagen
            FROM productos p
            INNER JOIN categoria c ON p.categoria_id = c.id";

            using (OleDbCommand command = new OleDbCommand(query, con))
            {
                OleDbDataAdapter adapter = new OleDbDataAdapter(command);
                adapter.Fill(productos_categoria);
            }

            return productos_categoria;
        }
    }
}
