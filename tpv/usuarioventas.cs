﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tpv
{
    public partial class usuarioventas : Form
    {
        private Conexion conexion;
        private ImageList imageListProductos;
        private ImageList imageListCategorias;

        public usuarioventas()
        {
            InitializeComponent();
            conexion = new Conexion();
            imageListProductos = new ImageList();
            imageListCategorias = new ImageList();

            imageListCategorias.ImageSize = new Size(50, 40);
            imageListProductos.ImageSize = new Size(90, 50);

            listView1.LargeImageList = imageListCategorias;
            listView2.LargeImageList = imageListProductos;

            CargarCategorias();
            CargarTabla();

        }
        private void CargarCategorias()
        {

            DataTable categorias = conexion.ObtenerCategorias();

            listView1.Items.Clear();
            imageListCategorias.Images.Clear();

            foreach (DataRow row in categorias.Rows)
            {
                //Obtiene el nombre de la categoria
                string nombre = row["nombre"].ToString();
                //Obtiene el nombre de la imagen y se crea una ruta directamente donde esta las imagenes guardadas de nuestro proyecto /images/categorias/".jpg"
                string image = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "categorias", row["imagen"].ToString());

                // si encuentra la imagen de la categoria, lo agrega a la lista de imagenes 
                if (File.Exists(image))
                {
                    imageListCategorias.Images.Add(nombre, Image.FromFile(image));
                }
                //creamos un elemento nuevo que estara dentro de la listview, este listview tiene dos parametros
                //cada item tendra el id de la categoria
                var item = new ListViewItem(nombre, nombre) { Tag = row["id"].ToString() };
                listView1.Items.Add(item);
            }

            //funcion que al cambiar la selección de una categoria 
            listView1.SelectedIndexChanged += (sender, e) =>
            {
                // si hay alguna categoria seleccionada
                if (listView1.SelectedItems.Count > 0)
                {
                    //obtiene el id de la categoria seleccionada y se guarada en categoriaId
                    string categoriaId = listView1.SelectedItems[0].Tag.ToString();
                    CargarProductosPorCategoria(categoriaId);
                }
            };
        }


        private void CargarProductosPorCategoria(string categoriaId)
        {
            DataTable productos = conexion.ObtenerProductosPorCategoria(categoriaId);
            listView2.Items.Clear();
            imageListProductos.Images.Clear();

            //obtiene la categoria seleccionada del listview1
            string selected_categoria = listView1.SelectedItems[0].Text;

            foreach (DataRow row in productos.Rows)
            {
                //obtiene el nombre y la imagen del producto
                string nombreProducto = row["nombre"].ToString();
                string imagen = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "images", "productos", selected_categoria, row["imagen"].ToString());


                //si encuentra la iamgen, lo agrega a la lista de imagenes de Productos
                if (File.Exists(imagen))
                {
                    imageListProductos.Images.Add(nombreProducto, Image.FromFile(imagen));
                }

                ListViewItem item = new ListViewItem(nombreProducto)
                {
                    ImageKey = nombreProducto,
                    Tag = row
                };

                listView2.Items.Add(item);
            }
        }

        private void CargarTabla()
        {

            dataGridView1.Columns.Add("Articulo", "Artículo");
            dataGridView1.Columns.Add("Precio", "Precio");
            dataGridView1.Columns.Add("Cantidad", "Cant.");
            dataGridView1.Columns.Add("Impuestos", "Impuestos");
            dataGridView1.Columns.Add("Importe", "Importe");

            dataGridView1.Columns["Precio"].DefaultCellStyle.Format = "C2";
            dataGridView1.Columns["Importe"].DefaultCellStyle.Format = "C2";
        }

        private void listView2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView2.SelectedItems.Count > 0)
            {
                DataRow producto = (DataRow)listView2.SelectedItems[0].Tag;
                string nombreProducto = producto["nombre"].ToString();
                decimal precio = Convert.ToDecimal(producto["precio"]);

                text_producto.Text = nombreProducto;
                text_precio.Text = precio.ToString("C2");
                text_cantidad.Text = "1";
            }
        }


        private void check_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(text_producto.Text) &&
                !string.IsNullOrEmpty(text_precio.Text) &&
                !string.IsNullOrEmpty(text_cantidad.Text) &&
                int.TryParse(text_cantidad.Text, out int cantidad))
            {
                string nombreProducto = text_producto.Text;
                decimal precio = decimal.Parse(text_precio.Text, System.Globalization.NumberStyles.Currency);
                decimal impuestos = 0;
                decimal importe = precio * cantidad;

                dataGridView1.Rows.Add(nombreProducto, precio, cantidad, $"{impuestos}%", importe);

                text_producto.Clear();
                text_precio.Clear();
                text_cantidad.Clear();
                ActualizarTotal();
            }
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                text_producto.Text = dataGridView1.CurrentRow.Cells["Articulo"].Value.ToString();
                text_precio.Text = dataGridView1.CurrentRow.Cells["Precio"].Value.ToString();
                text_cantidad.Text = dataGridView1.CurrentRow.Cells["Cantidad"].Value.ToString();
            }

        }

        private void cross_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.CurrentRow.Index);
                ActualizarTotal();

            }
        }


        private void edit_Click(object sender, EventArgs e)
        {
            decimal precio = decimal.Parse(text_precio.Text, System.Globalization.NumberStyles.Currency);
            int cantidad = int.Parse(text_cantidad.Text);
            decimal importe = precio * cantidad;

            dataGridView1.CurrentRow.Cells["Articulo"].Value = text_producto.Text;
            dataGridView1.CurrentRow.Cells["Precio"].Value = precio;
            dataGridView1.CurrentRow.Cells["Cantidad"].Value = cantidad;
            dataGridView1.CurrentRow.Cells["Importe"].Value = importe;

            text_producto.Clear();
            text_precio.Clear();
            text_cantidad.Clear();
            ActualizarTotal();

        }

        private void ActualizarTotal()
        {
            decimal total = 0;
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                total += Convert.ToDecimal(row.Cells["Importe"].Value);
            }
            text_total.Text = total.ToString("C2");
        }

        private void reservar_Click(object sender, EventArgs e)
        {
            this.Close();
            usuarioreservacs usuarioreserva = new usuarioreservacs();
            usuarioreserva.Show();
        }

        private void lista_Click(object sender, EventArgs e)
        {
            this.Close();
            usuariolistareservas usuariolistareservas = new usuariolistareservas();
            usuariolistareservas.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form = new Form1();
            form.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Verificar si hay productos en la tabla
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("No hay productos en la tabla.");
                return;
            }

            // Ruta donde se guardará el archivo .txt
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "ventas.txt");

            try
            {
                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    // Escribir encabezados en el archivo con formato alineado
                    writer.WriteLine("Artículo".PadRight(20) + "Precio".PadRight(10) + "Cantidad".PadRight(10) + "Importe".PadRight(10));
                    writer.WriteLine(new string('-', 50)); // Línea separadora

                    decimal total = 0;
                    foreach (DataGridViewRow row in dataGridView1.Rows)
                    {
                        string articulo = row.Cells["Articulo"].Value.ToString();
                        string precio = row.Cells["Precio"].Value.ToString();
                        string cantidad = row.Cells["Cantidad"].Value.ToString();
                        decimal importe = Convert.ToDecimal(row.Cells["Importe"].Value);
                        total += importe;

                        // Escribir en el archivo
                        writer.WriteLine($"{articulo}\t{precio}\t{cantidad}\t{importe}");

                        // Sumar al total, asegurándose de que importe se maneje como decimal
                        total += Convert.ToDecimal(importe, System.Globalization.CultureInfo.InvariantCulture);

                        // Obtener el productoId usando el nombre del producto
                        DataTable producto = conexion.ObtenerProductoPorNombre(articulo);

                        if (producto.Rows.Count > 0)
                        {
                            int productoId = Convert.ToInt32(producto.Rows[0]["id"]);
                            int cantidadVendida = int.Parse(cantidad);

                            // Llamar al método para actualizar el stock en la base de datos
                            conexion.ActualizarStockVenta(productoId, cantidadVendida);
                        }
                        else
                        {
                            MessageBox.Show($"No se encontró el producto '{articulo}' en la base de datos.");
                        }
                    }

                    // Escribir el total al final del archivo con formato de moneda alineado
                    writer.WriteLine(new string('-', 50)); // Línea separadora
                    writer.WriteLine("Total:".PadRight(40) + total.ToString("0.00").Replace(".", ",") + " €");

                    // Confirmar que la venta se procesó correctamente
                    MessageBox.Show("Venta registrada correctamente.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al procesar la venta: " + ex.Message);
            }
        }








    }
}
