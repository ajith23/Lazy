using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace LazyWeb.Models
{
    public class Application
    {
        public static int ApplicantsCount { get { return 2; } }
        public static Dictionary<string, int> DefaultApplicants
        {
            get
            {
                var temp = new Dictionary<string, int>();
                temp.Add("R", 1);
                temp.Add("A", 2);
                return temp;
            }
        }
        public string Company { get; set; }
        public int Priority { get; set; }
        public List<string> Applicants { get; set; }

        private static Dictionary<string, int>  _applicationDictionary = new Dictionary<string, int>();
        private Application(string company, int priority, List<string> applicants)
        {
            Company = company;
            Priority = priority;
            Applicants = applicants;
        }
        public static List<Application> ReadData(string path)
        {
            var lines = File.ReadAllLines(path);
            var applyList = new List<Application>();
            var index = 0;
            foreach(var line in lines)
            {
                var temp = line.Split(',');
                var list = new List<string>();
                for (var i =2; i<temp.Length; i++)
                {
                    list.Add(temp[i]);
                }
                var priority = 99;
                int.TryParse(temp[1], out priority);
                _applicationDictionary.Add(temp[0], index++);
                applyList.Add(new Application(temp[0], priority, list));
            }
            return applyList;
        }

        public void UpdateStatus(string path, string companyName, string user, string status)
        {
            var lines = File.ReadAllLines(path);
            var toUpdate = lines[_applicationDictionary[companyName]];
            var temp = toUpdate.Split(',');
            //TODO:
            lines[_applicationDictionary[companyName]] = companyName + "," + temp[1]; 

            File.WriteAllLines(path, lines);
        }
        public static void AddCompany (string path, string company, int priority)
        {
            var line = company + "," + priority;
            for (var i = 0; i < ApplicantsCount; i++)
                line += ",";
            File.AppendAllText(path, Environment.NewLine + line);
        }
    }
}