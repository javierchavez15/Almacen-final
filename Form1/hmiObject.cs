using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Drawing;

namespace Form1
{
    public class hmiObject : DbObject
    {
        private bool _TouchscreenActivo = false;

        public void MostrarValores(Form forma, bool TouchscreenActivo)
        {
            _TouchscreenActivo = TouchscreenActivo;
            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);


            foreach (Control control in forma.Controls)
            {
                string tipoControl = control.GetType().ToString();



                if (tipoControl == "System.Windows.Forms.TextBox")
                {
                    TextBox txtBox = (TextBox)control;
                    string Nombre;


                    for (int i = 0; i != miembros.Length; i++)
                    {
                        Nombre = miembros[i].Name;
                        if (miembros[i].Name == txtBox.Name)
                        {
                            string valor = miembros[i].GetValue(this).ToString();
                            txtBox.Text = valor;
                            txtBox.MouseDown += new MouseEventHandler(txtBox_MouseDown);
                            string tipoMiembro = miembros[i].GetValue(this).GetType().ToString();
                            if (!txtBox.ReadOnly)
                            {
                                txtBox.Tag = tipoMiembro;
                            }
                            break;

                        }
                    }
                }

                if (tipoControl == "System.Windows.Forms.CheckBox")
                {
                    CheckBox txtBox = (CheckBox)control;
                    string Nombre;


                    for (int i = 0; i != miembros.Length; i++)
                    {
                        Nombre = miembros[i].Name;
                        if (miembros[i].Name == txtBox.Name)
                        {

                            bool valor = bool.Parse(miembros[i].GetValue(this).ToString());
                            txtBox.Checked = valor;

                            break;

                        }
                    }
                }


            }
        }

        void txtBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (!_TouchscreenActivo) return;
            if (((TextBox)sender).Tag == null) return;
            object Tag = ((TextBox)sender).Tag.ToString();
            string tipo = Tag.ToString();
            if (tipo == "System.Int32")
            {
                libHMI.HMI.EntradaEnteroTouchscreen(sender);
                return;
            }
            if (tipo == "System.Double")
            {
                libHMI.HMI.EntradaDoubleTouchscreen(sender);
                return;
            }
            if (tipo == "Password")
            {
                libHMI.HMI.EntradaPassword(sender);
                return;
            }
            libHMI.HMI.EntradaTextoTouchscreen(sender);
        }

        public bool AsignarValores(Form forma)
        {
            bool TodoOK = true;
            FieldInfo[] miembros;
            Type tipo = this.GetType();
            miembros = tipo.GetFields(BindingFlags.Instance
                | BindingFlags.Public | BindingFlags.NonPublic);



            foreach (Control control in forma.Controls)
            {
                string tipoControl = control.GetType().ToString();

                if (tipoControl == "System.Windows.Forms.CheckBox")
                {
                    CheckBox txtBox = (CheckBox)control;
                    string Nombre;


                    for (int i = 0; i != miembros.Length; i++)
                    {
                        Nombre = miembros[i].Name;
                        if (miembros[i].Name == txtBox.Name)
                        {
                            string tipoMiembro = miembros[i].GetValue(this).GetType().ToString();

                            if (tipoMiembro == "System.Boolean")
                            {
                                miembros[i].SetValue(this, txtBox.Checked);
                            }


                            break;

                        }
                    }
                }


                if (tipoControl == "System.Windows.Forms.TextBox")
                {
                    TextBox txtBox = (TextBox)control;

                    string Nombre;


                    for (int i = 0; i != miembros.Length; i++)
                    {
                        Nombre = miembros[i].Name;
                        if (miembros[i].Name == txtBox.Name)
                        {


                            string tipoMiembro = miembros[i].GetValue(this).GetType().ToString();

                            try
                            {

                                if (tipoMiembro == "System.Double")
                                {
                                    miembros[i].SetValue(this, double.Parse(txtBox.Text));
                                }

                                if (tipoMiembro == "System.Int32")
                                {
                                    miembros[i].SetValue(this, int.Parse(txtBox.Text));
                                }

                                if (tipoMiembro == "System.String")
                                {
                                    miembros[i].SetValue(this, txtBox.Text);
                                }

                                if (tipoMiembro == "System.DateTime")
                                {
                                    miembros[i].SetValue(this, DateTime.Parse(txtBox.Text));
                                }

                                if (tipoMiembro == "System.Boolean")
                                {
                                    miembros[i].SetValue(this, bool.Parse(txtBox.Text));
                                }
                                if (!txtBox.ReadOnly)
                                {
                                    txtBox.BackColor = Color.White;
                                }
                            }
                            catch
                            {
                                txtBox.BackColor = Color.Yellow;
                                TodoOK = false;
                            }

                            break;

                        }
                    }



                }
            }

            return TodoOK;
        }

    }
}
