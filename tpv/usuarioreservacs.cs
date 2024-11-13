using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System;

namespace tpv
{
    public partial class usuarioreservacs : Form
    {
        Conexion conexion; 

        public usuarioreservacs()
        {
            InitializeComponent();
            conexion = new Conexion(); 
        }

        private void CargarEstadoMesas()
        {
            List<int> mesasReservadas = conexion.ObtenerReservas(); 

            foreach (Control control in this.Controls)
            {
                if (control is Button mesaButton)
                {
                    int numeroMesa = int.Parse(mesaButton.Name.Replace("mesa", "")); 

                    mesaButton.BackColor = mesasReservadas.Contains(numeroMesa) ? Color.Red : Color.Green;
                }
            }
        }

        private void Mesa_Click(object sender, EventArgs e)
        {
            Button mesaButton = sender as Button;
            int numeroMesa = int.Parse(mesaButton.Name.Replace("mesa", "")); 

            DateTime fechaReservaLocal = DateTime.Now;  
            TimeSpan horaReservaLocal = TimeSpan.Zero;  

            if (EsMesaReservada(numeroMesa, fechaReservaLocal, horaReservaLocal))
            {
                MessageBox.Show($"La mesa {numeroMesa} ya está reservada.");
            }
            else
            {
                Form reservaForm = new Form
                {
                    Text = $"Reservar Mesa {numeroMesa}",
                    Size = new Size(300, 300)
                };

                Label nombreLabel = new Label() { Text = "Nombre del Cliente:", Top = 20, Left = 10, Width = 150 };
                TextBox nombreTextBox = new TextBox() { Top = 40, Left = 10, Width = 250 };

                Label fechaLabel = new Label() { Text = "Fecha de la Reserva:", Top = 70, Left = 10, Width = 150 };
                DateTimePicker fechaPicker = new DateTimePicker() { Top = 90, Left = 10, Width = 250 };

                Label horaLabel = new Label() { Text = "Hora de la Reserva:", Top = 120, Left = 10, Width = 150 };
                DateTimePicker horaPicker = new DateTimePicker() { Top = 140, Left = 10, Width = 250, Format = DateTimePickerFormat.Custom, CustomFormat = "HH:mm" };

                Button confirmarButton = new Button() { Text = "Confirmar Reserva", Top = 180, Left = 10, Width = 250 };
                confirmarButton.Click += (senderConfirmar, eConfirmar) =>
                {
                    string nombreCliente = nombreTextBox.Text;
                    DateTime fechaReserva = fechaPicker.Value.Date;
                    TimeSpan horaReserva = horaPicker.Value.TimeOfDay;

                    RealizarReserva(numeroMesa, nombreCliente, fechaReserva, horaReserva);

                    reservaForm.Close();

                    CargarEstadoMesas();

                    MessageBox.Show($"La mesa {numeroMesa} ha sido reservada a nombre de {nombreCliente}.");
                };

                reservaForm.Controls.Add(nombreLabel);
                reservaForm.Controls.Add(nombreTextBox);
                reservaForm.Controls.Add(fechaLabel);
                reservaForm.Controls.Add(fechaPicker);
                reservaForm.Controls.Add(horaLabel);
                reservaForm.Controls.Add(horaPicker);
                reservaForm.Controls.Add(confirmarButton);

                reservaForm.ShowDialog();
            }
        }


        private bool EsMesaReservada(int numeroMesa, DateTime fechaReserva, TimeSpan horaReserva)
        {
            return conexion.EsHoraReservada(numeroMesa, fechaReserva, horaReserva);  
        }

        private void RealizarReserva(int numeroMesa, string nombreCliente, DateTime fechaReserva, TimeSpan horaReserva)
        {
            conexion.RealizarReserva(numeroMesa, nombreCliente, fechaReserva, horaReserva);
        }

        private void usuarioreservacs_Load(object sender, EventArgs e)
        {
            CargarEstadoMesas();
        }

        private void lista_Click(object sender, EventArgs e)
        {
            this.Close();
            usuariolistareservas usuariolistareservas = new usuariolistareservas();
            usuariolistareservas.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
            usuarioventas usuarioventas = new usuarioventas();
            usuarioventas.Show();
        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Close();
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
