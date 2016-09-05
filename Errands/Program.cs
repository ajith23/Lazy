using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Errands
{
    class Program
    {
        static void Main(string[] args)
        {
            Read();
            Console.ReadLine();
        }

        private static void Read()
        {
            var lines = System.IO.File.ReadAllLines(@"C:\AJ\ap.txt");
            var distinctLines = new List<string>();
            var list = new Dictionary<string, int>();
            var repeatCount = 0;
            foreach(var line in lines)
            {
                if (list.ContainsKey(line.Trim()))
                {
                    list[line.Trim()]++;
                    repeatCount++;
                    Console.WriteLine(line.Trim());
                }
                else
                {
                    distinctLines.Add(line.Trim());
                    list.Add(line.Trim(), 1);
                }
            }
            Console.WriteLine(repeatCount);
            Console.WriteLine(list.Count);

            System.IO.File.WriteAllLines(@"C:\AJ\app-distinct.txt", distinctLines);
        }
    }
}
