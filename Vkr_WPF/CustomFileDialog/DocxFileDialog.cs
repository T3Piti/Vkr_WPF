using Microsoft.Office.Interop.Word;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using System.Windows.Xps.Packaging;

namespace Vkr_WPF.CustomFileDialog
{
    public class DocxFileDialog
    {
        public string FileChooser(ref IDocumentPaginatorSource DocText, ref string FilePath)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.DefaultExt = ".docx";
            dlg.Filter = ".Docx Files (*.docx)|*.docx";
            Nullable<bool> result = dlg.ShowDialog();
            if (result == true)
            {
                FilePath = dlg.FileName;
                Application word = new Application();
                string newXPSDocumentName = String.Concat(System.IO.Path.GetDirectoryName(FilePath), "\\",
                           System.IO.Path.GetFileNameWithoutExtension(dlg.FileName), ".xps");
                DocText = ConvertWordDocToXPSDoc(FilePath, newXPSDocumentName).GetFixedDocumentSequence();
                return Path.GetFileName(FilePath);
            }
            DocText = null;
            FilePath = String.Empty;
            return String.Empty;
        }

        public byte[] ConvertToByte(string FileName) => File.ReadAllBytes(FileName);

        private XpsDocument ConvertWordDocToXPSDoc(string wordDocName, string xpsDocName)

        {

            // Create a WordApplication and add Document to it

            Microsoft.Office.Interop.Word.Application

                wordApplication = new Microsoft.Office.Interop.Word.Application();

            wordApplication.Documents.Add(wordDocName);





            Document doc = wordApplication.ActiveDocument;

            // You must ensure you have Microsoft.Office.Interop.Word.Dll version 12.

            // Version 11 or previous versions do not have WdSaveFormat.wdFormatXPS option

            try

            {

                doc.SaveAs(xpsDocName, WdSaveFormat.wdFormatXPS);

                wordApplication.Quit();



                XpsDocument xpsDoc = new XpsDocument(xpsDocName, System.IO.FileAccess.Read);

                return xpsDoc;

            }

            catch (Exception exp)

            {

                string str = exp.Message;

            }

            return null;

        }
    }
}
