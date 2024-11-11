using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace tpv
{
    public partial class usuarioreservacs : Form
    {
        Conexion conexion;  // Instancia la conexión de forma no estática

        public usuarioreservacs()
        {
            InitializeComponent();
            conexion = new Conexion(); // Instanciamos la clase Conexion
        }

        private void CargarEstadoMesas()
        {
            // Usa la instancia de conexion para llamar a ObtenerReservas
            List<int> mesasReservadas = conexion.ObtenerReservas(); // Llama a ObtenerReservas desde la clase Conexion

            foreach (Control control in this.Controls)
            {
                if (control is Button mesaButton)
                {
                    int numeroMesa = int.Parse(mesaButton.Name.Replace("mesa", "")); // Extrae el número de la mesa

                    // Establece el color de fondo dependiendo si la mesa está reservada o no
                    mesaButton.BackColor = mesasReservadas.Contains(numeroMesa) ? Color.Red : Color.Green;
                }
            }
        }

        private void Mesa_Click(object sender, EventArgs e)
        {
            Button mesaButton = sender as Button;
            int numeroMesa = int.Parse(mesaButton.Name.Replace("mesa", "")); // Extrae el número de la mesa

            // Renombrar las variables locales para evitar conflicto con los parámetros
            DateTime fechaReservaLocal = DateTime.Now;  // Usamos la fecha actual para la validación
            TimeSpan horaReservaLocal = TimeSpan.Zero;  // Usamos hora cero, pero esto debe ajustarse a tu lógica

            // Verifica si la mesa ya está reservada
            if (EsMesaReservada(numeroMesa, fechaReservaLocal, horaReservaLocal))
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


        private bool EsMesaReservada(int numeroMesa, DateTime fechaReserva, TimeSpan horaReserva)
        {
            // Verifica si la mesa está reservada en la fecha y hora proporcionadas
            return conexion.EsHoraReservada(numeroMesa, fechaReserva, horaReserva);  // Llama al método de la clase Conexion para verificar la reserva
        }

        private void RealizarReserva(int numeroMesa, string nombreCliente, DateTime fechaReserva, TimeSpan horaReserva)
        {
            // Realiza la reserva en la base de datos
            conexion.RealizarReserva(numeroMesa, nombreCliente, fechaReserva, horaReserva);
        }

        private void usuarioreservacs_Load(object sender, EventArgs e)
        {
            // Cargar el estado inicial de las mesas al cargar el formulario
            CargarEstadoMesas();
        }
    }
}
