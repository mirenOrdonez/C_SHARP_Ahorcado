using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C_SHARP_Ahorcado
{
    public partial class Form1 : Form
    {
        //Almacenamos la palabra que hay que adivinar
        String palabraOculta = "";
        //Almacenamos el número de fallos
        int numeroFallos = 0;

        public Form1()
        {
            InitializeComponent();
            palabraOculta = eligePalabra();
            String guion = "";
            for (int i = 0; i < palabraOculta.Length; i++) {
                guion = guion + "_ ";
            }
            label1.Text = guion;
        }

        private void letraPulsada(object sender, EventArgs e)
        {
            //Casteamos el objeto sender a botón
            Button miBoton = (Button)sender;
            //Deshabilitamos el botón una vez pulsado
            miBoton.Enabled = false;
            //Convertimos en String la letra que aparezca en el botón pulsado
            String letra = miBoton.Text;
            letra = letra.ToUpper();


            //Chequear si la letra está en la palabra oculta
            if (palabraOculta.Contains(letra))
            {
                int posicion = palabraOculta.IndexOf(letra);
                label1.Text = label1.Text.Remove(2 * posicion, 1).Insert(2 * posicion, letra);
            }
            else {
                numeroFallos++;
            }
            if (!label1.Text.Contains('_')) {
                numeroFallos = -100;
            }
            
            switch (numeroFallos) {
                case 0: pictureBox1.Image = Properties.Resources.ahorcado_0; break;
                case 1: pictureBox1.Image = Properties.Resources.ahorcado_1; break;
                case 2: pictureBox1.Image = Properties.Resources.ahorcado_2; break;
                case 3: pictureBox1.Image = Properties.Resources.ahorcado_3; break;
                case 4: pictureBox1.Image = Properties.Resources.ahorcado_4; break;
                case 5: pictureBox1.Image = Properties.Resources.ahorcado_5; break;
                case 6: pictureBox1.Image = Properties.Resources.ahorcado_fin; break;
                case 7: pictureBox1.Image = Properties.Resources.loser; break;
                case -100: pictureBox1.Image = Properties.Resources.acertastetodo; break;
                default: pictureBox1.Image = Properties.Resources.loser; break;
            }
        }

        //Array de palabras para elegir
        public String eligePalabra() {
            String[] listaPalabras = { "CANTINFLEAR", "MELIFLUO", "ATARAXIA", "APAIXONAR", "INEFABLE", "ZASCANDIL",
                                    "JOUSKA", "NAKAMA", "NEFELIBATA", "VERRIONDO"};
            Random aleatorio = new Random();
            int posicion = aleatorio.Next(listaPalabras.Length);
            return listaPalabras[posicion].ToUpper();
        }
    }
}
