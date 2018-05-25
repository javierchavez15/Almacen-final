using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using libBarCode;

namespace Form1
{
    public partial class FormOSASxPROYECTO : Form
    {
        public FormOSASxPROYECTO()
        {
            InitializeComponent();
        }

        osa_gral OSAseleccionada;
        public proyectos proyecto;
        clientes clienteSeleccionado;
        public string totales = "";

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

        private void FormOSASxPROYECTO_Load(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            dataGridView1.CellClick += new DataGridViewCellEventHandler(dataGridView1_CellClick);
            clienteSeleccionado = new clientes(proyecto.ID_CLIENTE);
            double total = 0;
            for (int a=0; a < dataGridView1.RowCount-1; a++)
            {
                if(dataGridView1[6,a].Value.ToString()!="")
              total = total + double.Parse(dataGridView1[6,a].Value.ToString());
               //MessageBox.Show(dataGridView1[6, a].Value.ToString());
            }
            //MessageBox.Show(total.ToString());
            lblcosto.Text = lblcosto.Text + Math.Round(total, 2).ToString();
            totales = Math.Round(total, 2).ToString();
        }
        
        
        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;
            if (dataGridView1.Rows[e.RowIndex].Cells[1].Value == DBNull.Value)
                return;
            int rowIndex = e.RowIndex;

            int idOSA = Convert.ToInt32(dataGridView1.Rows[rowIndex].Cells[0].Value);


            OSAseleccionada = new osa_gral(idOSA);

            FormOSA_INDIVIDUAL fosaI = new FormOSA_INDIVIDUAL();
            fosaI.osaSeleccionada = OSAseleccionada;
            fosaI.nombreCliente = clienteSeleccionado.RAZON_SOCIAL;
            fosaI.nombreVendedor = labelGerente.Text;

            fosaI.ShowDialog();

        }
        

        private void buttonCerrarProyecto_Click(object sender, EventArgs e)
        {

        }

        private void buttonIMPRIMIR_Click(object sender, EventArgs e)
        {
            SaveFileDialog save = new SaveFileDialog();
            save.DefaultExt = "pdf";
            save.Filter = "PDF files|*.pdf";

            if (save.ShowDialog() == DialogResult.OK)
            {
                string ruta = save.FileName;

                CreatePDF(ruta);
                System.Diagnostics.Process.Start(ruta);
            }
        }
        
        private void CreatePDF(string ruta)
        {

            using (FileStream msReport = new FileStream(ruta, FileMode.Create))
            {

                //step 1

                using (Document pdfDoc = new Document(PageSize.LETTER, 22f, 10f, 180f, 40f))
                {

                    try
                    {
                        // step 2
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                        ITextProyecto ITE = new ITextProyecto();
                        ITE.NombreDoc = "LISTA DE MATERIALES POR PROYECTO";
                        ITE.NoDoc = proyecto.ID.ToString();
                      //  ITE.CodigoDoc = OSAGralSeleccionada.CODIGODEBARRAS;
                        ITE.FechaDoc = DateTime.Now.Date;
                      //  ITE.NoFactura = OSAGralSeleccionada.FACTURA;
                      //  ITE.NoRemision = OSAGralSeleccionada.REMISION;
                      //  ITE.NoCotizacion = OSAGralSeleccionada.COTIZACION.ToString();                            
                        ITE.NombreCte = clienteSeleccionado.RAZON_SOCIAL;
                        ITE.NombreVendedor = proyecto.GERENTE;
                        ITE.total = totales;
                     //   ITE.NombreContacto = CONTACTO.Text;
                        ITE.NombreProyecto = proyecto.NOMBRE;

                        pdfWriter.PageEvent = ITE;


                        //open the stream 
                        pdfDoc.Open();


                        #region tablas

                        //     Conv conv = new Conv();

                        PdfPTable NombreColumnas2 = new PdfPTable(6);
                        NombreColumnas2.TotalWidth = pdfDoc.PageSize.Width - 90f;
                        NombreColumnas2.LockedWidth = true;
                        NombreColumnas2.WidthPercentage = 70;
                        float[] widths2 = new float[] { 1f, 1f, 4f, 8f, 1f, 1f };
                        NombreColumnas2.SetWidths(widths2);

                        #region foreach

                        DataTable dt = proyectos.osaProyecto(proyecto.ID);

                        foreach (DataRow dr in dt.Rows)
                        {
                            PdfPCell idOsa = new PdfPCell(new Phrase(dr["OSA"].ToString(), ITextProyecto.arial2));
                            idOsa.HorizontalAlignment = 1;
                            idOsa.VerticalAlignment = Element.ALIGN_MIDDLE;
                            NombreColumnas2.AddCell(idOsa);

                            PdfPCell item = new PdfPCell(new Phrase(dr["ITEM"].ToString(), ITextProyecto.arial2));
                            item.HorizontalAlignment = 1;
                            item.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  item.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(item);

                            PdfPCell Catalogo;


                            Catalogo = new PdfPCell(new Phrase(dr["CATALOGO"].ToString(), ITextProyecto.arial2));
                            //  PdfPCell Catalogo = new PdfPCell(new Phrase(partida.ALIAS, ITextEvents.arial2));
                            Catalogo.FixedHeight = 22f;
                            Catalogo.HorizontalAlignment = 0;
                            Catalogo.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Catalogo.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(Catalogo);


                            PdfPCell Descrip = new PdfPCell(new Phrase(dr["DESCRIPCION"].ToString(), ITextProyecto.arial2));
                            Descrip.HorizontalAlignment = 0;
                            Descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Descrip.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(Descrip);

                            PdfPCell Cantidad = new PdfPCell(new Phrase(dr["CANT"].ToString(), ITextProyecto.arial2));
                            Cantidad.HorizontalAlignment = 1;
                            Cantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(Cantidad);

                            PdfPCell Precio = new PdfPCell(new Phrase(dr["PRECIO"].ToString(), ITextProyecto.arial2));
                            Precio.HorizontalAlignment = 1;
                            Precio.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(Precio);

                        }
                        #endregion

                        PdfPCell espacio1 = new PdfPCell();
                        espacio1.FixedHeight = 8F;
                        espacio1.Colspan = 6;
                        espacio1.Border = 0;
                        NombreColumnas2.AddCell(espacio1);


                        NombreColumnas2.DefaultCell.PaddingBottom = 60;
                        NombreColumnas2.DefaultCell.PaddingTop = 60;

                        pdfDoc.Add(NombreColumnas2);

                        #endregion tablas



                        pdfDoc.Close();

                    }
                    catch (Exception ex)
                    {
                        //handle exception
                    }

                    finally
                    {


                    }



                }

            }
        }
        
    }
}
