using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SelectPdf;

namespace LazyWeb
{
    public class Utility
    {
        public static string pageSize = "Letter";
        public static string pageOrientation = "Portrait";
        public static int pageMargin = 25;
        public static Stream GeneratePDF(string htmlString)
        {
            // instantiate a html to pdf converter object
            var converter = new HtmlToPdf();
            converter.Options.PdfPageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pageSize, true); 
            converter.Options.PdfPageOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), pageOrientation, true);
            converter.Options.MarginBottom = pageMargin;
            converter.Options.MarginTop = pageMargin;
            converter.Options.MarginLeft = pageMargin;
            converter.Options.MarginRight = pageMargin;

            var document = converter.ConvertHtmlString(htmlString);
            document.Save(@"C:\AJ\Sample.pdf");
            document.Close();
            return new FileStream(@"C:\AJ\Sample.pdf", FileMode.Open, FileAccess.Read);
        }
        
        private PdfDocument GetDocument()
        {
            PdfDocument document = new PdfDocument();
            document.DocumentInformation.Title = "Cover Letter";
            document.DocumentInformation.Author = "Lazy-App";
            document.DocumentInformation.Subject = "Cover Letter for application";
            document.DocumentInformation.Keywords = "cover, profile";
            document.DocumentInformation.CreationDate = DateTime.Now;
            return document;
        }
    }
}