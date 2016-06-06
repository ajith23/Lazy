using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyWeb.Models
{
    public class Settings
    {
        public PrintSettings PrintPageSettings { get; set; }
    }

    public class PrintSettings
    {
        public string Size { get; set; }
        public string Orientation { get; set; }
        public int Margin { get; set; }
    }
}
