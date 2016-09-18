using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SelectPdf;
using System.Configuration;
using LazyWeb.Models;

namespace LazyWeb
{
    public class Utility
    {
        //public static string pageSize = "Letter";
        //public static string pageOrientation = "Portrait";
        //public static int pageMargin = 25;
        
        public static byte[] GeneratePDF(string htmlString, PrintSettings printSettings)
        {
            // instantiate a html to pdf converter object
            var converter = new HtmlToPdf();
            converter.Options.PdfPageSize = (PdfPageSize)Enum.Parse(typeof(PdfPageSize), printSettings.Size, true); 
            converter.Options.PdfPageOrientation = (PdfPageOrientation)Enum.Parse(typeof(PdfPageOrientation), printSettings.Orientation, true);
            converter.Options.MarginBottom = printSettings.Margin;
            converter.Options.MarginTop = printSettings.Margin;
            converter.Options.MarginLeft = printSettings.Margin;
            converter.Options.MarginRight = printSettings.Margin;
            converter.Options.EmbedFonts = true;
            converter.Options.InternalLinksEnabled = true;
            converter.Options.ColorSpace = PdfColorSpace.RGB;
            var document = converter.ConvertHtmlString(htmlString);
            document.Save(Constants.DownloadPath);
            document.Close();
            return File.ReadAllBytes(Constants.DownloadPath);
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
            //string currentKey = File.ReadAllText(Constants.KeyPath);
            //if (currentKey.Equals(key))
                authenticated = true;
            return authenticated;
        }

        internal static string GetUserAccess(string key)
        {
            var user = "A";
            var temp = key.Split('-');
            if (temp.Length > 1)
                user = temp[1];
            return user;
        }
    }
}