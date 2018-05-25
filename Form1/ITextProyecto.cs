using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.IO;
using System.Diagnostics;
using libBarCode;

namespace Form1
{
    public class ITextProyecto : PdfPageEventHelper
    {
         // This is the contentbyte object of the writer
        PdfContentByte cb;

        // we will put the final number of pages in a template
        PdfTemplate headerTemplate, footerTemplate, footerTemplate2;

        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;

        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;

        #region Properties

        private DateTime _FechaDoc;
        public DateTime FechaDoc
        {
            get { return _FechaDoc; }
            set { _FechaDoc = value; }
        }

        private string _NombreDoc;
        public string NombreDoc
        {
            get { return _NombreDoc; }
            set { _NombreDoc = value; }
        }

        private string _NoDoc;
        public string NoDoc
        {
            get { return _NoDoc; }
            set { _NoDoc = value; }
        }

        private string _CodigoDoc;
        public string CodigoDoc
        {
            get { return _CodigoDoc; }
            set { _CodigoDoc = value; }
        }

        private string _NoFactura;
        public string NoFactura
        {
            get { return _NoFactura; }
            set { _NoFactura = value; }
        }

        private string _NoCotizacion;
        public string NoCotizacion
        {
            get { return _NoCotizacion; }
            set { _NoCotizacion = value; }
        }

        private string _NoRemision;
        public string NoRemision
        {
            get { return _NoRemision; }
            set { _NoRemision = value; }
        }

        private string _NombreCte;
        public string NombreCte
        {
            get { return _NombreCte; }
            set { _NombreCte = value; }
        }

        private string _NombreContacto;
        public string NombreContacto
        {
            get { return _NombreContacto; }
            set { _NombreContacto = value; }
        }

        private string _NombreVendedor;
        public string NombreVendedor
        {
            get { return _NombreVendedor; }
            set { _NombreVendedor = value; }
        }

        private string _total;
        public string total
        {
            get { return _total; }
            set { _total = value; }
        }


        private string _NombreProveedor;
        public string NombreProveedor
        {
            get { return _NombreProveedor; }
            set { _NombreProveedor = value; }
        }

        private string _NombreProyecto;
        public string NombreProyecto
        {
            get { return _NombreProyecto; }
            set { _NombreProyecto = value; }
        }

        #endregion Properties

        #region TiposLetra

        public static iTextSharp.text.Font arial = FontFactory.GetFont("arial", 9, 0, BaseColor.BLACK);
        public static iTextSharp.text.Font arial2 = FontFactory.GetFont("arial", 8, 0, BaseColor.BLACK);
        public static iTextSharp.text.Font verdana = FontFactory.GetFont("Verdana", 15, 0, BaseColor.BLACK);

        #endregion TiposLetra

        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                headerTemplate = cb.CreateTemplate(200, 100);
                footerTemplate = cb.CreateTemplate(100, 50);
            }
            catch (DocumentException de)
            {

            }
            catch (System.IO.IOException ioe)
            {

            }
        }

        public override void OnEndPage(iTextSharp.text.pdf.PdfWriter writer, iTextSharp.text.Document document)
        {

            base.OnEndPage(writer, document);

            iTextSharp.text.Font baseFontNormal = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 12f, iTextSharp.text.Font.NORMAL, iTextSharp.text.BaseColor.BLACK);

            iTextSharp.text.Font baseFontBig = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 14f, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.BLACK);

            Phrase p1Header = new Phrase(NombreDoc, verdana);

            #region LOGOTIPO

            string fileName = "LOGODESCOELECTRIC.jpg";
            FileInfo f = new FileInfo(fileName);
            string fullname = f.FullName;


            //  FileInfo direccion = new FileInfo(@"C:\Documents and Settings\User\My Documents\Dropbox\DESCO\COTIZAR LUIGI");
            // string imageFilePath = @"C:\logoDesco/DESCO log.GIF";
            string imageFilePath = @"C:\logoDesco/LOGODESCOELECTRIC.jpg";
            iTextSharp.text.Image jpg = iTextSharp.text.Image.GetInstance(imageFilePath);
            jpg.ScaleToFit(80f, 80f);
            // jpg.IsNestable();
            jpg.SetAbsolutePosition(0, 0);
            //LOGOTIPO
            //  jpg.SpacingBefore = 30f;
            // jpg.SpacingAfter = 1f;
            // jpg.Alignment = Element.ALIGN_LEFT;

            //  FileInfo direccion2 = new FileInfo("LOG2.PNG");
            //  string imageFilePath2 = direccion2.DirectoryName + "/LOG2.PNG";

            /* 
             string imageFilePath2 = @"C:\logoDesco/LOG2.PNG";
             iTextSharp.text.Image jpg2 = iTextSharp.text.Image.GetInstance(imageFilePath2);
             jpg2.ScaleToFit(115f, 115f);
             // jpg.IsNestable();
             jpg2.SetAbsolutePosition(0, 0);
             */

            #endregion LOGOTIPO

            String text2 = "Blvd. Federico Benítez 401-B La mesa, Tijuana B.C. C.P.22105 Tel/Fax: 6262712 http//:www.descoelectric.com";
            String text = "Page " + writer.PageNumber + " of ";

            #region Numeracion de pagina y Fijacion de LOGOTIPO
            //Add paging to header
            {
                headerTemplate.AddImage(jpg);
                //     headerTemplate.AddImage(jpg2);
                cb.AddTemplate(headerTemplate, 50, 842 - 125);
                /*  cb.BeginText();
                  cb.SetFontAndSize(bf, 12);
                  cb.SetTextMatrix(document.PageSize.GetRight(200), document.PageSize.GetTop(45));
                  cb.ShowText(text);
                  cb.EndText();
                  float len = bf.GetWidthPoint(text, 12);
                  //Adds "12" in Page 1 of 12
                  cb.AddTemplate(headerTemplate, document.PageSize.GetRight(200) + len, document.PageSize.GetTop(45));
           */
            }

            //Agregar la direccion al Footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(480), document.PageSize.GetBottom(10));
                cb.ShowText(text2);
                cb.EndText();
                //  float len = bf.GetWidthPoint(text, 10);
                //   cb.AddTemplate(footerTemplate2, document.PageSize.GetRight(700), document.PageSize.GetBottom(25));

            }
            //Add paging to footer
            {
                cb.BeginText();
                cb.SetFontAndSize(bf, 8);
                cb.SetTextMatrix(document.PageSize.GetRight(330), document.PageSize.GetBottom(25));
                cb.ShowText(text);
                cb.EndText();
                float len = bf.GetWidthPoint(text, 8);
                cb.AddTemplate(footerTemplate, document.PageSize.GetRight(330) + len, document.PageSize.GetBottom(25));
            }

            #endregion Numeracion de pagina y Fijacion de LOGOTIPO

            #region Tabla Titulo y Numero de Cotizacion
            //Create PdfTable object
            PdfPTable pdfTab = new PdfPTable(3);

            //We will have to create separate cells to include image logo and 2 separate strings
            //Row 1
            PdfPCell pdfCell1 = new PdfPCell();
            PdfPCell pdfCell2 = new PdfPCell(p1Header);
            //set the alignment of all three cells and set border to 0
            pdfCell1.HorizontalAlignment = Element.ALIGN_LEFT;
            pdfCell2.HorizontalAlignment = Element.ALIGN_CENTER;
            pdfCell2.VerticalAlignment = Element.ALIGN_TOP;

            pdfCell1.Border = 0;
            pdfCell2.Border = 0;

            //TABLA ANIDADA DE NUMERO DE COTIZACION Y FECHA

            PdfPTable table = new PdfPTable(1);
            table.TotalWidth = 124f;
            table.LockedWidth = true;
            table.HorizontalAlignment = 2;

            PdfPTable nestedTable = new PdfPTable(1);
            table.WidthPercentage = 100;

            PdfPCell header = new PdfPCell(new Phrase(8, "No. " + NoDoc, arial2));
            header.HorizontalAlignment = 1;
            // header.BackgroundColor = BaseColor.LIGHT_GRAY;

           

            /*
            PdfPCell header2 = new PdfPCell(new Phrase(8,CodigoDoc, arial2));
            header2.HorizontalAlignment = 1;
            header2.Border = 0;
            nestedTable.AddCell(header2);
            */


            PdfPCell header3 = new PdfPCell(new Phrase(8, "Fecha: " + FechaDoc.Day + "/" + FechaDoc.Month + "/" + FechaDoc.Year, arial2));
            header3.HorizontalAlignment = 1;
            // header2.BackgroundColor = BaseColor.LIGHT_GRAY;
            /*
            PdfPCell header4 = new PdfPCell(new Phrase(8, "Factura: " + NoFactura, arial2));
            header4.HorizontalAlignment = 1;
            //   header3.BackgroundColor = BaseColor.LIGHT_GRAY;

            PdfPCell header5 = new PdfPCell(new Phrase(8, "Remision: " + NoRemision, arial2));
            header5.HorizontalAlignment = 1;

            PdfPCell header6 = new PdfPCell(new Phrase(8, "Cotizacion: " + NoCotizacion, arial));
            header6.HorizontalAlignment = 1;
            */
            //TITULO,NUMERO Y FECHA

            table.AddCell(header);
     //       table.AddCell(header4);
      //      table.AddCell(cellx);
            table.AddCell(header3);
     //       table.AddCell(header5);
     //       table.AddCell(header6);


            PdfPCell anidado = new PdfPCell(table);
            anidado.HorizontalAlignment = 2;
            anidado.Border = 0;


            //TITULO,NUMERO Y FECHA

            //add all three cells into PdfTable
            pdfTab.AddCell(pdfCell1);
            pdfTab.AddCell(pdfCell2);
            pdfTab.AddCell(anidado);

            pdfTab.TotalWidth = document.PageSize.Width - 80f;
            pdfTab.WidthPercentage = 70;
            //pdfTab.HorizontalAlignment = Element.ALIGN_CENTER;



            //call WriteSelectedRows of PdfTable. This writes rows from PdfWriter in PdfTable
            //first param is start row. -1 indicates there is no end row and all the rows to be included to write
            //Third and fourth param is x and y position to start writing
            pdfTab.WriteSelectedRows(0, -1, 40, document.PageSize.Height - 50, writer.DirectContent);

            #endregion Tabla Titulo y Numero de Cotizacion

            #region Tabla Nombre del PROYECTO

            PdfPTable tablaCte = new PdfPTable(2);
            tablaCte.TotalWidth = document.PageSize.Width - 95f;
            tablaCte.LockedWidth = true;
            tablaCte.WidthPercentage = 70;
            float[] widths = new float[] { 1f, 3f };
            tablaCte.SetWidths(widths);
            tablaCte.SpacingAfter = 10;

            PdfPCell cte = new PdfPCell(new Phrase("PROYECTO:", arial));
            cte.Border = 0;
            cte.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(cte);

            PdfPCell cte2 = new PdfPCell(new Phrase(NombreProyecto, arial));
            cte2.Border = 0;
            cte2.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(cte2);

            /*      PdfPCell b = new PdfPCell();
                  b.Border = 0;
                  b.Colspan = 2;
                  // cte.VerticalAlignment = Element.ALIGN_CENTER;
                  tablaCte.AddCell(b);
      

*/
            PdfPCell proyecto = new PdfPCell(new Phrase("GERENTE DE PROYECTO:", arial));
            proyecto.Border = 0;
            proyecto.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(proyecto);

            PdfPCell proyecto2 = new PdfPCell(new Phrase(NombreVendedor, arial2));
            proyecto2.Border = 0;
            proyecto2.VerticalAlignment = Element.ALIGN_CENTER;
            tablaCte.AddCell(proyecto2);

            PdfPCell cto = new PdfPCell(new Phrase("CLIENTE:", arial));
            cto.Border = 0;
            cto.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaCte.AddCell(cto);

            PdfPCell cto2 = new PdfPCell(new Phrase(NombreCte, arial2));
            cto2.Border = 0;
            cto2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaCte.AddCell(cto2);

            PdfPCell total = new PdfPCell(new Phrase("COSTO TOTAL EN DOLLAR:", arial));
            total.Border = 0;
            total.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaCte.AddCell(total);

            PdfPCell total2 = new PdfPCell(new Phrase(_total, arial2)); 
             total2.Border = 0;
            total2.VerticalAlignment = Element.ALIGN_MIDDLE;
            tablaCte.AddCell(total2);

            tablaCte.WriteSelectedRows(0, -1, 50, document.PageSize.Height - 110, writer.DirectContent);

            #endregion Tabla Nombre del PROVEEDOR

            #region Titulos de Columnas

            PdfPTable NombreColumnas = new PdfPTable(6);
            NombreColumnas.TotalWidth = document.PageSize.Width - 90f;
            NombreColumnas.LockedWidth = true;
            NombreColumnas.WidthPercentage = 70;
            float[] widths2 = new float[] { 1f, 1f, 4f, 8f, 1f, 1f };
            NombreColumnas.SetWidths(widths2);

            PdfPCell Osa = new PdfPCell(new Phrase("OSA", arial2));
            Osa.HorizontalAlignment = 1;
            Osa.VerticalAlignment = Element.ALIGN_MIDDLE;
            Osa.BackgroundColor = BaseColor.LIGHT_GRAY;
            NombreColumnas.AddCell(Osa);

            PdfPCell item = new PdfPCell(new Phrase("ITEM", arial2));
            item.HorizontalAlignment = 1;
            item.VerticalAlignment = Element.ALIGN_MIDDLE;
            item.BackgroundColor = BaseColor.LIGHT_GRAY;
            NombreColumnas.AddCell(item);

            PdfPCell Catalogo = new PdfPCell(new Phrase("CATALOGO", arial2));
            Catalogo.HorizontalAlignment = 1;
            Catalogo.VerticalAlignment = Element.ALIGN_MIDDLE;
            Catalogo.BackgroundColor = BaseColor.LIGHT_GRAY;
            NombreColumnas.AddCell(Catalogo);

            PdfPCell Descrip = new PdfPCell(new Phrase("DESCRIPCION", arial2));
            Descrip.HorizontalAlignment = 1;
            Descrip.VerticalAlignment = Element.ALIGN_MIDDLE;
            Descrip.BackgroundColor = BaseColor.LIGHT_GRAY;
            NombreColumnas.AddCell(Descrip);

            PdfPCell Cantidad = new PdfPCell(new Phrase("CANT.", arial2));
            Cantidad.HorizontalAlignment = 1;
            Cantidad.VerticalAlignment = Element.ALIGN_MIDDLE;
            Cantidad.BackgroundColor = BaseColor.LIGHT_GRAY;
            NombreColumnas.AddCell(Cantidad);

            PdfPCell Precio = new PdfPCell(new Phrase("COSTO", arial2));
            Precio.HorizontalAlignment = 1;
            Precio.VerticalAlignment = Element.ALIGN_MIDDLE;
            Precio.BackgroundColor = BaseColor.LIGHT_GRAY;
            NombreColumnas.AddCell(Precio);  

            NombreColumnas.WriteSelectedRows(0, -1, 51, document.PageSize.Height - 170, writer.DirectContent);

            #endregion Titulos de Columnas

            //set pdfContent value

            //Move the pointer and draw line to separate header section from rest of page
            /*   cb.MoveTo(40, document.PageSize.Height - 100);
                cb.LineTo(document.PageSize.Width - 40, document.PageSize.Height - 100);
                cb.Stroke();

                //Move the pointer and draw line to separate footer section from rest of page
                cb.MoveTo(40, document.PageSize.GetBottom(50));
                cb.LineTo(document.PageSize.Width - 40, document.PageSize.GetBottom(50));
                cb.Stroke();
         */
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
            /*
                        headerTemplate.BeginText();
                        headerTemplate.SetFontAndSize(bf, 12);
                        headerTemplate.SetTextMatrix(0, 0);
                        headerTemplate.ShowText((writer.PageNumber - 1).ToString());
                        headerTemplate.EndText();
            */
            footerTemplate.BeginText();
            footerTemplate.SetFontAndSize(bf, 8);
            footerTemplate.SetTextMatrix(0, 0);
            footerTemplate.ShowText((writer.PageNumber - 1).ToString());
            footerTemplate.EndText();
        }

    }
}
