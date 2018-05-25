using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Form1
{
    public partial class FormPROYECTOS : Form
    {
        public FormPROYECTOS()
        {
            InitializeComponent();
        }

        proyectos proyectoSeleccionado;

        private void buttonBUSQUEDA_Click(object sender, EventArgs e)
        {
            BuscarProyecto();
        }

        private void BuscarProyecto()
        {
            int idProyecto = 0;
            string descripcionProyecto = "";
            int statusProyecto = 0;

            if (radioButtonABIERTO.Checked == false)
            {
                statusProyecto = 1; //cerrado
            }

            if (radioButtonID.Checked == true && textBoxBusqueda.Text != "")
            {
                idProyecto = Convert.ToInt32(textBoxBusqueda.Text);
            }
            else
            {
                descripcionProyecto = textBoxBusqueda.Text;
            }


            proyectos p = new proyectos();
            try
            {
                dataGridView1.DataSource = p.proyectos2(idProyecto, descripcionProyecto, statusProyecto);
                dataGridView1.Columns[1].Width = 900;
            }
            catch
            {
                MessageBox.Show("No existen proyectos aun");
            }
        }

        private void textBoxBusqueda_TextChanged(object sender, EventArgs e)
        {
            if (radioButtonID.Checked == true)
            {
                if (textBoxBusqueda.Text != "")
                {
                    try
                    {
                        int numero = Convert.ToInt32(textBoxBusqueda.Text);
                    }
                    catch
                    {
                        MessageBox.Show("Escriba Numero de ID");
                        textBoxBusqueda.Text = "";
                    }
                }
            }
        }

        private void FormPROYECTOS_Load(object sender, EventArgs e)
        {
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;

            int idProyecto = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);

            if (idProyecto > 0)
            {
                proyectoSeleccionado = new proyectos(idProyecto);

                FormOSASxPROYECTO oxp = new FormOSASxPROYECTO();

                oxp.dataGridView1.DataSource = proyectos.osaProyecto(idProyecto);
                oxp.dataGridView1.Columns[0].Width = 50;
                oxp.dataGridView1.Columns[1].Width = 30;
                oxp.dataGridView1.Columns[2].Width = 200;
                oxp.dataGridView1.Columns[3].Width=600;
                oxp.dataGridView1.Columns[4].Width = 50;                

                oxp.labelGerente.Text = "Gerente "+ proyectoSeleccionado.GERENTE;
                oxp.labelIdProyecto.Text = "Proyecto # "+ proyectoSeleccionado.ID.ToString();
                oxp.labelNombreProyecto.Text = "Descripcion: "+ proyectoSeleccionado.NOMBRE;
                oxp.labelNombreCliente.Text = "Cliente "+proyectoSeleccionado.ID_CLIENTE.ToString();
                string estatus = "";
                if (proyectoSeleccionado.STATUS == 0)
                {
                    estatus = "Abierto";
                    oxp.buttonReabrirProyecto.Visible = false;
                    oxp.buttonCerrarProyecto.Visible = true;
                   
                }
                else
                {
                    estatus = "Cerrado";
                    oxp.buttonReabrirProyecto.Visible = true;
                    oxp.buttonCerrarProyecto.Visible = false;
                   
                }

                oxp.labelStatusProyecto.Text = "ESTATUS: " + estatus;
                oxp.proyecto = proyectoSeleccionado;

                oxp.ShowDialog();

                if (oxp.DialogResult == DialogResult.Yes)
                {
                    proyectoSeleccionado.STATUS = 0;
                    proyectoSeleccionado.Update("ID");
                    MessageBox.Show("Proyecto Abierto");
                    BuscarProyecto();
                }
                if (oxp.DialogResult == DialogResult.No)
                {
                    proyectoSeleccionado.STATUS = 1;
                    proyectoSeleccionado.Update("ID");
                    MessageBox.Show("Proyecto Cerrado");
                    BuscarProyecto();
                }

            }

           
            
            

        }
    }
}
