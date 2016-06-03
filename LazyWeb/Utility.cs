using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SelectPdf;
using System.Configuration;

namespace LazyWeb
{
    public class Utility
    {
        public static string NoAuthMessage = "You are not Authenticated, or your session is expired.";
        public static string pageSize = "Letter";
        public static string pageOrientation = "Portrait";
        public static int pageMargin = 25;
        public static string downloadPath = @"C:\lazy-downloads\CoverSample.pdf";
        public static string keyPath = @"C:\lazy-downloads\key.txt";
        public static byte[] GeneratePDF(string htmlString)
        {
            // instantiate a html to pdf converter object
            var converter = new HtmlToPdf();
            converter.Options.PdfPageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), pageSize, true); 
            converter.Options.PdfPageOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), pageOrientation, true);
            converter.Options.MarginBottom = pageMargin;
            converter.Options.MarginTop = pageMargin;
            converter.Options.MarginLeft = pageMargin;
            converter.Options.MarginRight = pageMargin;
            converter.Options.EmbedFonts = true;
            converter.Options.InternalLinksEnabled = true;
            converter.Options.ColorSpace = PdfColorSpace.RGB;
            var document = converter.ConvertHtmlString(htmlString);
            document.Save(downloadPath);
            document.Close();
            return File.ReadAllBytes(downloadPath);
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

        public static bool IsAuthenticated(string key)
        {
            var authenticated = false;
            string currentKey = File.ReadAllText(keyPath);
            if (currentKey.Equals(key))
                authenticated = true;
            return authenticated;
        }
    }
}