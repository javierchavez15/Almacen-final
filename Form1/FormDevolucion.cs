using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Form1
{
    public partial class FormDevolucion : Form
    {
        public FormDevolucion()
        {
            InitializeComponent();
        }

        public int existencia;
        public int stock;
        int existenciaTope;

        private void buttonDisminuir_Click(object sender, EventArgs e)
        {
            if (existencia > 0)
            {
                existencia--;
                stock++;
                textBoxExistencia.Text = existencia.ToString();                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (existencia < existenciaTope)
            {
                ++existencia;
                stock--;
                textBoxExistencia.Text = existencia.ToString();
            } 
        }

        private void FormDevolucion_Load(object sender, EventArgs e)
        {
            existenciaTope = existencia;            
        }

        private void button4_Click(object sender, EventArgs e)
        {    
        }

        private void button3_Click(object sender, EventArgs e)
        {
        }

        private void button6_Click(object sender, EventArgs e)
        {
            int sumaResta;
            try
            {
                sumaResta = Convert.ToInt32(textBoxSUMARESTA.Text);
            }
            catch
            {
                MessageBox.Show("Escriba solo numeros");
                return;
            }
            if (sumaResta > 0)
            {
                existencia = existencia - sumaResta;
                stock = stock + sumaResta;
            }      
            textBoxExistencia.Text = existencia.ToString();
            textBoxSUMARESTA.Text = "";
        }

        private void buttonAddFull_Click(object sender, EventArgs e)
        {
            if (existencia < existenciaTope)
            {
                int sumaResta;
                try
                {
                    sumaResta = Convert.ToInt32(textBoxSUMARESTA.Text);
                }
                catch
                {
                    MessageBox.Show("Escriba solo numeros");
                    return;
                }

                if (sumaResta > 0)
                {
                    existencia = existencia + sumaResta;
                    stock = stock - sumaResta;
                }   
                textBoxExistencia.Text = existencia.ToString();
                textBoxSUMARESTA.Text = "";
            } 
        }
    }
}
