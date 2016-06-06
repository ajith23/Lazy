using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LazyWeb.Models
{
    public class Resume
    {
        public Personal PersonalData { get; set; }
        public List<Education> EducationList { get; set; }
        public List<Experience> ExperienceList { get; set; }
        public List<Project> ProjectList { get; set; }
        public List<Skill> SkillList { get; set; }
    }

    public class Personal
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string GithubLink { get; set; }
        public string LinkedinLink { get; set; }
        public string WebsiteLink { get; set; }
        public string Other { get; set; }
        public string Objective { get; set; }

        public static Personal GetDummyData()
        {
            return new Personal
            {
                FirstName = "Ajith",
                LastName = "V",
                Email = "avimalch@asu.edu",
                Phone = "(480) 326 - 7284",
                GithubLink = "https://github.com/ajith23",
                LinkedinLink = "https://www.linkedin.com/in/ajithv23",
                Id=1
            };
        }
    }

    public class Education
    {
        public int Id { get; set; }
        public string DisplayString { get; set; } //eg: Master of Computer Science, Arizona State University, USA | CGPA 3/4
        public List<string> CourseWork { get; set; }
        public string Timeline { get; set; } //eg: (May 2016 - Present)

        public static List<Education> GetDummyData()
        {
            var educationList = new List<Education>();
            educationList.Add(new Education
            {
                Id = 1,
                DisplayString = "Master of Computer Science, Arizona State University, USA | CGPA <b>3.74/4</b>",
                Timeline= "<i>(January 2015 - December 2017)</i>"
            });
            educationList.Add(new Education
            {
                Id = 2,
                DisplayString = "Bachelor of Engineering in Computer Science and Engineering, Anna University, India | CGPA <b>8.76/10</b>",
                Timeline= "<i>(August 2007 - May 2011)</i>"
            });
            return educationList;
        }
    }

    public class Experience
    {
        public int Id { get; set; }
        public string DisplayString { get; set; } //eg: Software Developer Intern, AZ, USA
        public List<string> ContributionList { get; set; }
        public string Timeline { get; set; } //eg: (May 2016 - Present)

        public static List<Experience>  GetDummyData()
        {
            var experienceList = new List<Experience>();
            experienceList.Add(new Experience
            {
                Id = 1,
                DisplayString = "Software Developer Intern-  <b>Axosoft, AZ, USA</b>",
                Timeline = "<i>(May 2016 - upto August 2016)</i>"
            });
            experienceList.Add(new Experience
            {
                Id = 1,
                DisplayString = "Application Developer -  <b>Arizona State University, USA</b>",
                Timeline = "<i>(March 2015 - May 2016)</i>"
            });
            experienceList.Add(new Experience
            {
                Id = 1,
                DisplayString = "Senior Software Engineer - <b>Bosch, India</b>",
                Timeline = "<i>(July 2011 - December 2014)</i>"
            });
            return experienceList;
        }
    }

    public class Project
    {
        public int Id { get; set; }
        public string DisplayString { get; set; }
        public string Description { get; set; }
        public List<string> ContributionList { get; set; }
        public string Timeline { get; set; } //eg: (May 2016 - Present)
        public static List<Project> GetDummyData()
        {
            var projectList = new List<Project>();
            projectList.Add(new Project
            {
                Id = 1,
                DisplayString = "Time Management System – Python, Django, Git ",
                Timeline = "<i>(Jan 2016 – May 2016)</i>"
            });
            projectList.Add(new Project
            {
                Id = 1,
                DisplayString = "Adaptive Quiz – Java, Git, MySQL",
                Timeline = "<i>(Jan 2016 – May 2016)</i>"
            });
            projectList.Add(new Project
            {
                Id = 1,
                DisplayString = "Geospatial Operations - Apache Spark, Java",
                Timeline = "<i>(Aug 2015 – Dec 2015)</i>"
            });
            return projectList;
        }
    }

    public class Skill
    {
        public int Id { get; set; }
        public string SkillTag { get; set; }
        public string Category { get; set; }
        public double Weight { get; set; }
    }
}
