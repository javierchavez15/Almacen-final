using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Net.Security;

namespace Form1
{
    public partial class FormDocumentos : Form
    {
        public FormDocumentos()
        {
            InitializeComponent();
        }

        public int idproducto = 0;
        public string catalogo = "";

        private void FormDocumentos_Load(object sender, EventArgs e)
        {
            txtcatalogo.Text = catalogo;
            dataGridView1.DataSource= documentos_almacen.docementosproducto(idproducto);
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            try
            {
                FolderBrowserDialog fldDlg = new FolderBrowserDialog();
                string fileName = dataGridView1[2, e.RowIndex].Value.ToString();
                string rutaservidor = "ftp://ftp.abdstock.com/respaldos/" + fileName;
                //descargarFic(rutaservidor, "abdsto5", "1945*abdstock", @"c:\Descoa");
                string targetPath = @"c:\Descoa\documentos";
                if (!(Directory.Exists(@"c:\Descoa\")))
                {
                    Directory.CreateDirectory(@"c:\Descoa\");
                }
                if (!(Directory.Exists(targetPath)))
                {
                    Directory.CreateDirectory(targetPath);
                }
                string destFile = System.IO.Path.Combine(targetPath, fileName);
                Download("C:\\Descoa\\documentos\\", fileName);
                if (System.IO.File.Exists(destFile))
                    System.Diagnostics.Process.Start(destFile);
            }
            catch
            { }
        }

        private void Download(string filePath, string fileName)
        {
            string ftpServerIP;
            string ftpUserID;
            string ftpPassword;
            ftpServerIP = "ftp.abdstock.com";
            ftpUserID = "abdsto5";
            ftpPassword = "1945*abdstock";
            FtpWebRequest reqFTP;
            try
            {
                //filePath = <<La direcci�n / path completa donde el archivo sera creado.>>, 
                //fileName = <<Nombre del archivo a ser creado(Necesario el nombre del archovo en el FTP server).>>
                FileStream outputStream;
                try
                {
                    outputStream = new FileStream(filePath + fileName, FileMode.Create);
                }
                catch
                {
                    return;
                }

                reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/documentos/" + fileName));
                reqFTP.Method = WebRequestMethods.Ftp.DownloadFile;
                reqFTP.UseBinary = true;
                reqFTP.Credentials = new NetworkCredential(ftpUserID, ftpPassword);
                FtpWebResponse response = (FtpWebResponse)reqFTP.GetResponse();
                Stream ftpStream = response.GetResponseStream();
                long cl = response.ContentLength;
                int bufferSize = 2048;
                int readCount;
                byte[] buffer = new byte[bufferSize];

                readCount = ftpStream.Read(buffer, 0, bufferSize);
                while (readCount > 0)
                {
                    outputStream.Write(buffer, 0, readCount);
                    readCount = ftpStream.Read(buffer, 0, bufferSize);
                }

                ftpStream.Close();
                outputStream.Close();
                response.Close();
                //MessageBox.Show("Archivo: n" + fileName + "Bajado con �xito!...", "Atenci�n!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
