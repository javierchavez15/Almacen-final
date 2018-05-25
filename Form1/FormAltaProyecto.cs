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
    public partial class FormAltaProyecto : Form
    {
        public FormAltaProyecto()
        {
            InitializeComponent();
            radioButton1.Enabled = false;
            radioButton2.Enabled = false;
            txtproyecto.Enabled = false;
            NOMBRE.Enabled = false;
            ID_CLIENTE.Enabled = false;
            buttonAlta.Enabled = false;
        }

        clientes clienteSeleccionado;
        usuario empleadoSeleccionado;
       public proyectos proyectoSelected;

        public bool AccesoInternet()
        {
            try
            {
                System.Net.IPHostEntry host = System.Net.Dns.GetHostEntry("www.descoa.com");
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(GERENTE.Text=="" || txtproyecto.Text=="" || NOMBRE.Text=="" || ID_CLIENTE.Text=="")
            {
                return;
            }

            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            if (NOMBRE.Text == "")
            {
                MessageBox.Show("Escriba Nombre del Proyecto");
                return;
            }

            if (ID_CLIENTE.SelectedIndex==-1)
            {
                MessageBox.Show("SELECCIONE UN CLIENTE");
                return;
            }

            if (GERENTE.SelectedIndex==-1)
            {
                MessageBox.Show("SELECCIONE UN GERENTE");
                return;
            }
            if (txtproyecto.Text == "" || NOMBRE.Text == "" || clienteSeleccionado == null || empleadoSeleccionado == null)
                return;
            try
            {
                Convert.ToDouble(txtanticipo.Text);
            }
            catch
            {
                txtanticipo.Text = "0";
            }
            proyectos p = new proyectos();
            p.ID = Convert.ToInt32(txtproyecto.Text);
            p.NOMBRE = NOMBRE.Text;
            p.ID_CLIENTE = clienteSeleccionado.ID;
            p.GERENTE = empleadoSeleccionado.Nombre;

            p.idvendedor = empleadoSeleccionado.ID;
            p.fechainicio = dtinicio.Value.Date;
            p.fechafinal = dtfin.Value.Date;
            p.anticipo = Convert.ToDouble(txtanticipo.Text);


            p.Insert();
            proyectoSelected = p;
            MessageBox.Show("Alta Existosa");
        }

        private void FormAltaProyecto_Load(object sender, EventArgs e)
        {
            txtanticipo.Text = "0";
            ID_CLIENTE.DataSource = clientes.GetExistentes();
            GERENTE.DataSource = usuario.GetExistentes();

            ID_CLIENTE.SelectedIndex = -1;
            GERENTE.SelectedIndex = -1;
        }

        private void ID_CLIENTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ID_CLIENTE.SelectedIndex != -1)
            {
                clienteSeleccionado = (clientes)ID_CLIENTE.SelectedItem;
                buttonAlta.Enabled = true;
            }
        }

        private void GERENTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (GERENTE.SelectedIndex != -1)
            {
                empleadoSeleccionado = (usuario)GERENTE.SelectedItem;
                radioButton1.Enabled = true;
                radioButton2.Enabled = true;
                if (radioButton1.Checked == true)
                    txtproyecto.Text = generarproyecto();
            }
        }

        private void buttonAltaCliente_Click(object sender, EventArgs e)
        {
            FormAltaCliente c = new FormAltaCliente();
            c.ShowDialog();
        }

        private void buttonAltaGerente_Click(object sender, EventArgs e)
        {
            FormAltaEmpleado a = new FormAltaEmpleado();
            a.ShowDialog();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {            
            if (empleadoSeleccionado != null && GERENTE.Text != "" && GERENTE.SelectedIndex != -1)
            {
                txtproyecto.ReadOnly = true;
                txtproyecto.Enabled = true;
                txtproyecto.Text = generarproyecto();
            }
            else if(radioButton1.Checked == true)
            { MessageBox.Show("ELIGA EL GERENTE"); radioButton1.Checked = false; }
        }

        public string generarproyecto()//genera el numero del proyecto
        {
            string numero = "0";
            DateTime date1 = DateTime.Now.Date;
            int fecha = Convert.ToInt32(date1.ToString("yy"));//2 primeros digitos, son el año
            DataRow[] row;
            //row = datos.Select("Nombre LIKE '%" + cbvendedor.Text + "%'");
            int id = empleadoSeleccionado.ID;//el tercer digito es el id del vendedor
            int rango1 = Convert.ToInt32(fecha.ToString() + id.ToString("0#") + "000");//intervalo inferior
            int rango2 = Convert.ToInt32(fecha.ToString() + (id + 1).ToString("0#") + "000");//intervalo superior
            proyectos proy = new proyectos();
            DataTable ultimo = proy.Tabla("SELECT max(Id) FROM proyectos WHERE `Id`>" + rango1.ToString() + " and `Id`<" + rango2.ToString());//ultimo numero
            if (ultimo.Rows[0][0].ToString() != "")
            {
                numero = ultimo.Rows[0][0].ToString();
            }
            else
            {
                numero = rango1.ToString();
            }
            int año = Convert.ToInt32(numero);
            año++;
            numero = año.ToString();
            return numero;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            txtproyecto.ReadOnly = false;
            txtproyecto.Enabled = true;
        }

        private void txtproyecto_TextChanged(object sender, EventArgs e)
        {
            NOMBRE.Enabled = true;
        }

        private void NOMBRE_TextChanged(object sender, EventArgs e)
        {
            ID_CLIENTE.Enabled = true;
        }
    }
}
