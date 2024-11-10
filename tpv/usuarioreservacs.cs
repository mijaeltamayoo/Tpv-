using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace tpv
{
    public partial class usuarioreservacs : Form
    {
        private Conexion conexion;

        public usuarioreservacs()
        {
            InitializeComponent();
            conexion = new Conexion(); // Instanciamos la clase Conexion
        }

        // Método para cargar el estado de las mesas (reservada o disponible)
        private void CargarEstadoMesas()
        {
            // Obtener todas las reservas de la base de datos para la fecha actual o futura
            var reservas = conexion.ObtenerReservas();

            // Recorrer todos los botones de mesas y verificar si están reservadas
            foreach (Control control in this.Controls)
            {
                if (control is Button mesaButton)
                {
                    int numeroMesa = int.Parse(mesaButton.Name.Replace("mesa", "")); // Extrae el número de la mesa
                    bool mesaReservada = reservas.Contains(numeroMesa);

                    // Si la mesa está reservada, ponerla en rojo, si no, en verde (disponible)
                    mesaButton.BackColor = mesaReservada ? Color.Red : Color.Green;
                }
            }
        }

        // Cargar las reservas al inicio del formulario
        private void usuarioreservacs_Load(object sender, EventArgs e)
        {
            CargarEstadoMesas(); // Cargar el estado de las mesas
        }

        private void Mesa_Click(object sender, EventArgs e)
        {
            Button mesaButton = sender as Button;
            int numeroMesa = int.Parse(mesaButton.Name.Replace("mesa", "")); // Extrae el número de la mesa

            // Verifica si la mesa ya está reservada
            if (EsMesaReservada(numeroMesa))
            {
                MessageBox.Show($"La mesa {numeroMesa} ya está reservada.");
            }
            else
            {
                // Crear un formulario para ingresar los detalles de la reserva
                Form reservaForm = new Form
                {
                    Text = $"Reservar Mesa {numeroMesa}",
                    Size = new Size(300, 300)
                };

                // Nombre del cliente
                Label nombreLabel = new Label() { Text = "Nombre del Cliente:", Top = 20, Left = 10, Width = 150 };
                TextBox nombreTextBox = new TextBox() { Top = 40, Left = 10, Width = 250 };

                // Fecha de la reserva
                Label fechaLabel = new Label() { Text = "Fecha de la Reserva:", Top = 70, Left = 10, Width = 150 };
                DateTimePicker fechaPicker = new DateTimePicker() { Top = 90, Left = 10, Width = 250 };

                // Hora de la reserva
                Label horaLabel = new Label() { Text = "Hora de la Reserva:", Top = 120, Left = 10, Width = 150 };
                DateTimePicker horaPicker = new DateTimePicker() { Top = 140, Left = 10, Width = 250, Format = DateTimePickerFormat.Custom, CustomFormat = "HH:mm" };

                // Botón para confirmar la reserva
                Button confirmarButton = new Button() { Text = "Confirmar Reserva", Top = 180, Left = 10, Width = 250 };
                confirmarButton.Click += (senderConfirmar, eConfirmar) =>
                {
                    string nombreCliente = nombreTextBox.Text;
                    DateTime fechaReserva = fechaPicker.Value.Date; // Solo fecha (sin hora)
                    TimeSpan horaReserva = horaPicker.Value.TimeOfDay;

                    // Realiza la reserva
                    RealizarReserva(numeroMesa, nombreCliente, fechaReserva, horaReserva);

                    // Cierra el formulario de reserva
                    reservaForm.Close();

                    // Actualiza el estado de las mesas
                    CargarEstadoMesas();

                    // Muestra un mensaje de confirmación
                    MessageBox.Show($"La mesa {numeroMesa} ha sido reservada a nombre de {nombreCliente}.");
                };

                // Añadir controles al formulario
                reservaForm.Controls.Add(nombreLabel);
                reservaForm.Controls.Add(nombreTextBox);
                reservaForm.Controls.Add(fechaLabel);
                reservaForm.Controls.Add(fechaPicker);
                reservaForm.Controls.Add(horaLabel);
                reservaForm.Controls.Add(horaPicker);
                reservaForm.Controls.Add(confirmarButton);

                // Mostrar el formulario para hacer la reserva
                reservaForm.ShowDialog();
            }
        }

        // Método que verifica si la mesa ya está reservada
        private bool EsMesaReservada(int numeroMesa)
        {
            // Verificar si la mesa está reservada en la base de datos
            return conexion.EsMesaReservada(numeroMesa);
        }

        // Método que realiza la reserva y guarda el número de la mesa
        private void RealizarReserva(int numeroMesa, string nombreCliente, DateTime fechaReserva, TimeSpan horaReserva)
        {
            // Llamada al método de la clase Conexion para realizar la reserva
            conexion.RealizarReserva(numeroMesa, nombreCliente, fechaReserva, horaReserva);
        }
    }
}