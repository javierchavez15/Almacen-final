using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Form1
{
    public class SimpleFileCopy
    {
        public static void Copiar(string nombreArchivo, string rutaOrigen, string rutaDestino)
        {
           // string fileName = nombreArchivo;
           // string sourcePath = rutaOrigen;
           // string targetPath = rutaDestino;

            // Use Path class to manipulate file and directory paths.
            string sourceFile = rutaOrigen;
            string destFile = Path.Combine(rutaDestino, nombreArchivo);

            // To copy a folder's contents to a new location:
            // Create a new target folder, if necessary.
            if (File.Exists(destFile))
            {

                // Initializes the variables to pass to the MessageBox.Show method.

                string message = "Ya existe una archivo para este producto. Desea reemplazarlo?";
                string caption = "File Detected in Input";
                MessageBoxButtons buttons = MessageBoxButtons.YesNo;
                DialogResult result;

                // Displays the MessageBox.

                result = MessageBox.Show(message, caption, buttons);

                if (result == System.Windows.Forms.DialogResult.Yes)
                {                   
                    File.Copy(sourceFile, destFile,true);
                }
                
            }
            else
            {

                // To copy a file to another location and 
                // overwrite the destination file if it already exists.
                File.Copy(sourceFile, destFile, true);
            }
            // To copy all the files in one directory to another directory.
            // Get the files in the source folder. (To recursively iterate through
            // all subfolders under the current directory, see
            // "How to: Iterate Through a Directory Tree.")
            // Note: Check for target path was performed previously
            //       in this code example.
            /*
            if (System.IO.Directory.Exists(sourcePath))
            {
                string[] files = System.IO.Directory.GetFiles(sourcePath);

                // Copy the files and overwrite destination files if they already exist.
                foreach (string s in files)
                {
                    // Use static Path methods to extract only the file name from the path.
                    fileName = System.IO.Path.GetFileName(s);
                    destFile = System.IO.Path.Combine(targetPath, fileName);
                    System.IO.File.Copy(s, destFile, true);
                }
            }
            else
            {
                Console.WriteLine("Source path does not exist!");
            }

            // Keep console window open in debug mode.
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
            */
        }

    }
}
