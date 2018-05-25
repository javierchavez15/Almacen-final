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
    public partial class FormListaExistencias : Form
    {
        public FormListaExistencias()
        {
            InitializeComponent();
        }

        productos existencias;
        List<productos> ListaProductosE = new List<productos>();
        DataTable tablaSeleccionada;

        private void FormListaExistencias_Load(object sender, EventArgs e)
        {
            comboBoxMarca.SelectedIndex = 0;
           
        }

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

        private void comboBoxMarca_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (AccesoInternet() == false)
            { MessageBox.Show("No hay internet, intente en un momento"); return; }
            string marca = comboBoxMarca.Text;
           // MessageBox.Show(marca);
            tablaSeleccionada = productos.listaExistencias(marca).Copy();
            dataGridView1.DataSource = tablaSeleccionada;           
            dataGridView1.Columns[0].Visible = false;
            dataGridView1.Columns[1].Width = 220;
           // dataGridView1.Columns[2].Visible = false;
            dataGridView1.Columns[2].Width = 600;
            dataGridView1.Columns[5].Width = 130;


        }

        private void buttonImprimir_Click(object sender, EventArgs e)
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

                using (Document pdfDoc = new Document(PageSize.LETTER, 22f, 10f, 90f, 40f))
                {

                    try
                    {
                        // step 2
                        PdfWriter pdfWriter = PdfWriter.GetInstance(pdfDoc, msReport);
                        ITextExistencias ITEx = new ITextExistencias();
                        ITEx.NombreDoc = "LISTA DE EXISTENCIAS";
                        ITEx.FechaDoc = DateTime.Now;


                        pdfWriter.PageEvent = ITEx;


                        //open the stream 
                        pdfDoc.Open();


                        #region tablas

                        //     Conv conv = new Conv();

                        PdfPTable NombreColumnas2 = new PdfPTable(5);
                        NombreColumnas2.TotalWidth = pdfDoc.PageSize.Width - 90f;
                        NombreColumnas2.LockedWidth = true;
                        NombreColumnas2.WidthPercentage = 70;
                        float[] widths2 = new float[] { 2f, 4f, 1f, 1f, 1f };
                        NombreColumnas2.SetWidths(widths2);

                        #region foreach
                        foreach (DataRow producto in tablaSeleccionada.Rows)
                        {

                            PdfPCell Catalogo;
                            Catalogo = new PdfPCell(new Phrase(producto["CATALOGO"].ToString(), ITextExistencias.arial2));
                            //  PdfPCell Catalogo = new PdfPCell(new Phrase(partida.ALIAS, ITextEvents.arial2));
                            Catalogo.FixedHeight = 22f;
                            Catalogo.HorizontalAlignment = 0;
                            Catalogo.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Catalogo.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(Catalogo);


                            PdfPCell Descrip = new PdfPCell(new Phrase(producto["DESCRIPCION"].ToString(), ITextExistencias.arial2));
                            Descrip.HorizontalAlignment = 0;
                            Descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Descrip.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(Descrip);

                            PdfPCell marca = new PdfPCell(new Phrase(producto["MARCA"].ToString(), ITextExistencias.arial2));
                            marca.HorizontalAlignment = 1;
                            marca.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(marca);

                            PdfPCell stock = new PdfPCell(new Phrase(producto["STOCK"].ToString(), ITextExistencias.arial2));
                            stock.HorizontalAlignment = 1;
                            stock.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(stock);

                            PdfPCell coordenada = new PdfPCell(new Phrase(producto["COORDENADA"].ToString(), ITextExistencias.arial2));
                            coordenada.HorizontalAlignment = 1;
                            coordenada.VerticalAlignment = Element.ALIGN_MIDDLE;
                            //  Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
                            NombreColumnas2.AddCell(coordenada);

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
