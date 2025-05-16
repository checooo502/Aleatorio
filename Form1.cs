using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        int intentos = 0; //iniciar la variable intentos
        Random rand = new Random(); //Crear el objeto rand con la funcion random
        int aleatorio = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {

            intentos = 5; //cantidad de intentos
            txtintentos.Text = intentos.ToString();
            aleatorio = rand.Next(1, 100); //numero de uno a cien
        }
        private void label1_Click(object sender, EventArgs e)
        { 

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtnumero.Text, out int num))
            {
                if (num == aleatorio)
                {
                    MessageBox.Show($"Gano el juego! el numero es {aleatorio}");
                    DialogResult resultado = MessageBox.Show("¿Quiere volver a Jugar?", "Reintentar", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (resultado == DialogResult.No)
                    {
                        MessageBox.Show("Gracias por Jugar :)");
                        Application.Exit();
                    }
                    else
                    {
                        intentos = 5;
                        txtintentos.Text = intentos.ToString();
                        aleatorio = rand.Next(1, 100);
                    }
                }
                if (num > aleatorio)
                {
                    MessageBox.Show($"{num} es mayor al numero por adivinar");
                    intentos = intentos - 1;
                    txtintentos.Text = intentos.ToString();
                }
                if (num < aleatorio)
                {
                    MessageBox.Show($"{num} es menor al numero por adivinar");
                    intentos = intentos - 1;
                    txtintentos.Text = intentos.ToString();
                }
                if (intentos == 0)
                {
                    DialogResult resultado = MessageBox.Show("Se acabaron tus intentos. Quieres intentar de nuevo?", "Derrota :(", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                    if (resultado == DialogResult.No)
                    {
                        MessageBox.Show("suerte para la proxima");
                        Application.Exit();
                    }
                    else
                    {
                        intentos = 5;
                        txtintentos.Text = intentos.ToString();
                        aleatorio = rand.Next(1, 100);
                    }
                }
            }
            else
            {
                MessageBox.Show("ingresa un numero valido");
            }
        }
    }
}
