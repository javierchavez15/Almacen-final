using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace Form1
{
    class polizasdb : hmiObject
    {
        #region variables globales de poliza
        public int ID = 0;//1
        public int folio = 0;//2
        public DateTime fecha = DateTime.Now.Date;//3
        public string titulo = "";//4
        public string moneda = "";//5
        public double subtotal = 0;//6
        public double iva = 0;//7
        public double ingreso = 0;//8
        public double egreso = 0;//9
        public DateTime fechaoperacion = DateTime.Now.Date;//10
        public string factura = "";//11
        public string origen = "";//12
        public string suborigen = "";//13
        public string destino = "";//14
        public string subdestino = "";//15
        public string notas = "";//16
        public string tipo = "";//17
        public int estatus = 0;//18
        public string adjunto1 = "";//19
        public string adjunto2 = "";//20
        public double saldo = 0;//21
        public int estatus2 = 0;//22
        public string numero = "";//23
        public double saldoglobal = 0;//24
        public string programado = "";//25
        public string proveedor = "";//26
        public string deducible = "";//27
        public double tipocambio = 0;//28
        public double porcentajemargen = 0;//29
        public int id_ordencompra = 0;//30
        public double retension = 0;//31
        public double retension_isr = 0;//32
        public double saldo2 = 0;//33
        public double saldo3 = 0;//34
        public double saldo4 = 0;//35
        public double importacion = 0;//36
        public double saldopreimportacion = 0;//37
        public double dolar = 0; //38
        public double saldo5 = 0;//39
        public int prefactura = 0;//40
        public int idnegocio = 0;//41
        public int idpedimento = 0;//42
        public int devolucion = 0;//42
        public string pocliente = "";//44
        public string invoice = "";//45
        public int idproyecto = 0;//46
        public int idcliente = 0;//47
        public string remision = "";
        #endregion variables globales
        public static double paridad = 0;
        DataBase bdMysql;

        public polizasdb()
        {
        }

        public polizasdb(int id)
        {
            this.LoadMembers("folio=" + id);
        }

        public polizasdb(DataRow dr)
        {
            this.LoadDataRow(dr);
        }

        public void Insertarpoliza(FormSALIDAS formpolizas, string titulos)//insertar nueva orden
        {
            MySqlConnectionStringBuilder sb = new MySqlConnectionStringBuilder();
            
             sb.Server = "secure199.inmotionhosting.com";
             sb.UserID = "abdsto5_felipe";
             sb.Password = "1945Inadescobi";
             sb.Database = "abdsto5_cotizaciones";
          

            //PRUEBAS EN LOCALHOST
            /*
            sb.Server = "localhost";
            sb.UserID = "felipe";
            sb.Password = "1945Inadescobi";
            sb.Database = "ejemplo";
           */
            bdMysql = new DataBase();
            bdMysql.DataBaseProvider = TypeOfDataBase.MySqlServer;
            bdMysql.ConnectionString = sb.ToString();
            bdMysql.CreateConnection();
            DbObject.DefaultDataBaseObject = bdMysql;


            ID = 0;
            actualizarfolio:
            try
            {
                folio = this.NextNumber("folio");
                fecha = DateTime.Now.Date;
                titulo = titulos;
                if (formpolizas.REMISION.Text != "")
                    titulo = titulo + "Remision: " + formpolizas.REMISION.Text + "\n";
                if (formpolizas.COTIZACION.Text != "")
                    titulo = titulo + "Cotizacion: " + formpolizas.COTIZACION.Text + "\n";
                if (formpolizas.checkBoxPorProyecto.Checked == true) 
                    titulo = titulo + "Proyecto: " + formpolizas.comboBoxProyecto.Text +" "+ formpolizas.textBoxProyectoId.Text +"\n";
                moneda = "USD";
                subtotal = Math.Round(formpolizas.sumatoria, 2);
                iva = 0;
                ingreso = 0;
                egreso = Math.Round(formpolizas.sumatoria, 2);
                fechaoperacion = DateTime.Now.Date;
                factura = formpolizas.FACTURA.Text;
                pocliente = formpolizas.txtpo.Text;
                remision = formpolizas.REMISION.Text;
                if(remision=="")
                    remision = formpolizas.COTIZACION.Text;
                origen = "ALMACEN";
                suborigen = "N/A";
                if (formpolizas.checkBoxPorProyecto.Checked == true)
                    destino = "PREFACTURA PROYECTOS";
                else
                    destino = "PREFACTURA PRODUCTOS";
                subdestino = formpolizas.comboBoxClientes.Text;
                notas = "SALIDA AUTOMATICA DE ALMACEN";
                tipo = "EGRESO";
                estatus = 1;
                adjunto1 = "";
                saldo = 0;
                estatus2 = 1;
                numero = "";
                saldoglobal = 0;
                proveedor = "";
                porcentajemargen = 0;
                programado = "";
                if (estatus == 1 && origen != "PROVEEDORES")
                    programado = "pagado";
                if (origen == "CAJA" || origen == "PROVEEDORES" || origen == "BRANNSTORE" || origen == "PRE IMPORTACION")
                    programado = "";
                if (estatus == 2)
                    programado = "pagado";
                deducible = "NO";
                tipocambio = Convert.ToDouble(formpolizas.textBoxTipoCambio.Text);
                retension = 0;
                retension_isr = 0;
                saldo2 = 0; 
                saldo3 = 0;
                saldo4 = 0;
                if (formpolizas.comboVendedor.Text == "Felipe Ortiz" || formpolizas.comboVendedor.Text == "Oficina" || formpolizas.comboVendedor.Text == "Antonio Viera") 
                    idnegocio = 1;
                else if (formpolizas.comboVendedor.Text == "Jesus ortiz")
                    idnegocio = 19;
                else if (formpolizas.comboVendedor.Text == "Samuel" || formpolizas.comboVendedor.Text == "Taller")
                    idnegocio = 18;
                else
                    idnegocio = 3;
                idproyecto = formpolizas.idproyectos;
                
                pocliente = formpolizas.txtpo.Text;
                if (formpolizas.checkBoxPorProyecto.Checked == true)
                {
                    prefactura = Convert.ToInt32(this.factura(idproyecto.ToString()));
                }
                else 
                {
                    idproyecto = 0;
                    if (formpolizas.txtpo.Text != "" && formpolizas.txtpo.Text != "0")
                        prefactura = Convert.ToInt32(this.facturapoliza(pocliente));

                }
                this.Insert();
                if (this.Error != "")
                    goto actualizarfolio;
                else

                    formpolizas.OSAGralSeleccionada.actualizarosa("idpoliza", folio.ToString(), "Id="+ formpolizas.OSAGralSeleccionada.Id.ToString());
            }
            catch
            {
                goto actualizarfolio;
            }
        }
    }

}
