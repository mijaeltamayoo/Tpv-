using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tpv
{
    public partial class usuariolistareservas : Form
    {
        Conexion conexion;
        public usuariolistareservas()
        {
            InitializeComponent();
            conexion = new Conexion();

            CargarReservas();
        }


        private void CargarReservas()
        {
            DataTable reservas = conexion.ObtenerTodasLasReservas();

            if (!reservas.Columns.Contains("hora_formateada"))
            {
                reservas.Columns.Add("hora_formateada", typeof(string));
            }

            foreach (DataRow row in reservas.Rows)
            {
                if (row["hora_reserva"] != DBNull.Value && row["hora_reserva"] is DateTime dateTimeValue)
                {
                    row["hora_formateada"] = dateTimeValue.ToString("HH:mm");
                }
            }

            dataGridView1.DataSource = reservas;

            dataGridView1.Columns["id"].Visible = false;
            dataGridView1.Columns["hora_reserva"].Visible = false;

            dataGridView1.Columns["numero_mesa"].HeaderText = "Numero de mesa";
            dataGridView1.Columns["nombre_cliente"].HeaderText = "Cliente";
            dataGridView1.Columns["fecha_reserva"].HeaderText = "Fecha de reserva";
            dataGridView1.Columns["hora_formateada"].HeaderText = "Hora";  
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                text_mesa.Text = dataGridView1.CurrentRow.Cells["numero_mesa"].Value.ToString();
                text_cliente.Text = dataGridView1.CurrentRow.Cells["nombre_cliente"].Value.ToString();

                if (DateTime.TryParse(dataGridView1.CurrentRow.Cells["fecha_reserva"].Value.ToString(), out DateTime fecha))
                {
                    text_fecha.Text = fecha.ToString("yyyy/MM/dd"); 
                }

                text_hora.Text = dataGridView1.CurrentRow.Cells["hora_formateada"].Value.ToString();
            }
        }

        private void cross_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult result = MessageBox.Show($"¿Quieres eliminar esta reserva?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    int id = (int)dataGridView1.CurrentRow.Cells["id"].Value;

                    conexion.EliminarReserva(id);
                    MessageBox.Show("Reserva eliminada");
                    CargarReservas();
                }
            }
        }

        private void edit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Selecciona una reserva para editar.");
                return;
            }

            var result = MessageBox.Show("¿Estás seguro de que deseas editar esta reserva?", "Confirmar edición", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                if (string.IsNullOrEmpty(text_mesa.Text) || string.IsNullOrEmpty(text_cliente.Text) || string.IsNullOrEmpty(text_fecha.Text) || string.IsNullOrEmpty(text_hora.Text))
                {
                    MessageBox.Show("Completa todos los campos antes de editar.");
                    return;
                }

                if (!int.TryParse(text_mesa.Text, out int numeroMesa))
                {
                    MessageBox.Show("Número de mesa no válido.");
                    return;
                }

                string nombreCliente = text_cliente.Text;

                if (!DateTime.TryParse(text_fecha.Text, out DateTime fechaReserva))
                {
                    MessageBox.Show("Fecha no válida. Usa el formato AAAA/MM/DD.");
                    return;
                }

                if (!TimeSpan.TryParse(text_hora.Text, out TimeSpan horaReserva))
                {
                    MessageBox.Show("Hora no válida. Usa el formato HH:mm.");
                    return;
                }

                if (conexion.MesaYaReservada(numeroMesa, fechaReserva, horaReserva))
                {
                    MessageBox.Show("Esta mesa ya está reservada para esta hora.");
                    return;
                }

                DateTime fechaHoraReserva = fechaReserva.Date + horaReserva;

                int idReserva;
                if (int.TryParse(dataGridView1.CurrentRow.Cells["id"].Value.ToString(), out idReserva))
                {
                    conexion.EditarReserva(idReserva, numeroMesa, nombreCliente, fechaReserva, horaReserva);
                    MessageBox.Show("Reserva actualizada exitosamente.");
                    CargarReservas(); 
                }
                else
                {
                    MessageBox.Show("El ID de la reserva no es válido.");
                }
            }
        }

        private void check_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(text_mesa.Text) || string.IsNullOrEmpty(text_cliente.Text) || string.IsNullOrEmpty(text_fecha.Text) || string.IsNullOrEmpty(text_hora.Text))
            {
                MessageBox.Show("Completa todos los campos antes de realizar la reserva.");
                return;
            }

            if (!int.TryParse(text_mesa.Text, out int numeroMesa))
            {
                MessageBox.Show("Número de mesa no válido.");
                return;
            }

            string nombreCliente = text_cliente.Text;

            if (!DateTime.TryParse(text_fecha.Text, out DateTime fechaReserva))
            {
                MessageBox.Show("Fecha no válida. Usa el formato AAAA/MM/DD.");
                return;
            }

            if (!TimeSpan.TryParse(text_hora.Text, out TimeSpan horaReserva))
            {
                MessageBox.Show("Hora no válida. Usa el formato HH:mm.");
                return;
            }

            if (conexion.MesaYaReservada(numeroMesa, fechaReserva, horaReserva))
            {
                MessageBox.Show("Esta mesa ya está reservada para esta hora.");
                return;
            }

            conexion.RealizarReserva(numeroMesa, nombreCliente, fechaReserva, horaReserva);

            CargarReservas();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            usuarioventas usuarioventas = new usuarioventas();
            usuarioventas.Show();

        }

        private void reservar_Click(object sender, EventArgs e)
        {
            this.Close();
            usuarioreservacs usuarioreservacs = new usuarioreservacs();
            usuarioreservacs.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }

}
