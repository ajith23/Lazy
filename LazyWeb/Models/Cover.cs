using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LazyWeb.Models
{
    public class Cover
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Version { get; set; }
        public string Template { get; set; }
        public string FileNameTemplate { get; set; }

        public static List<Cover> GetDummyData()
        {
            var list = new List<Cover>();
            list.Add(new Cover { Id = 1, UserId = 1, Version = "Version 1", Template = GetDummyTemplate(1) });
            list.Add(new Cover { Id = 2, UserId = 1, Version = "Version 2", Template = GetDummyTemplate() });
            list.Add(new Cover { Id = 3, UserId = 1, Version = "Version 3", Template = GetDummyTemplate() });
            list.Add(new Cover { Id = 4, UserId = 1, Version = "Aj", Template = GetDummyTemplate(4) });
            return list;
        }

        private static string GetDummyTemplate(int id = 0)
        {
            if (id == 1)
                return GetCover1();
            else if (id == 4)
                return GetMyCover();
            return @"<p style='text-align: center; font-size: 15px;'><img title='TinyMCE Logo' src='//www.tinymce.com/images/glyph-tinymce@2x.png' alt='TinyMCE Logo' width='110' height='97' /></p>
                    <h1 style='text-align: center;'>Welcome to the TinyMCE editor demo!</h1>
                    <p>{Please try} out the features provided in this full featured example.</p>
                    <p>Note that any <strong>MoxieManager</strong> file and image management functionality in this example is part of our commercial offering &ndash; the demo is to show the integration.</p>
                    <h2>Got {questions or need} help?</h2>
                    <ul>
                    <li>Our <a href='//www.tinymce.com/docs/'>documentation</a> is a great resource for learning how to configure TinyMCE.</li>
                    <li>Have a specific question? Visit the <a href='http://community.tinymce.com/forum/'>Community Forum</a>.</li>
                    <li>We also offer enterprise grade support as part of <a href='http://tinymce.com/pricing'>TinyMCE Enterprise</a>.</li>
                    </ul>
                    <h2>A {simple table} to play with</h2>
                    <table style='text-align: center;'>
                    <thead>
                    <tr>
                    <th>Product</th>
                    <th>Cost</th>
                    <th>Really?</th>
                    </tr>
                    </thead>
                    <tbody>
                    <tr>
                    <td>TinyMCE</td>
                    <td>Free</td>
                    <td>YES!</td>
                    </tr>
                    <tr>
                    <td>Plupload</td>
                    <td>Free</td>
                    <td>YES!</td>
                    </tr>
                    </tbody>
                    </table>
                    <h2>Found a bug?</h2>
                    <p>If you think you have found a bug please create an issue on the <a href='https://github.com/tinymce/tinymce/issues'>GitHub repo</a> to report it to the developers.</p>
                    <h2>Finally ...</h2>
                    <p>Don't forget to check out our other product <a href='http://www.plupload.com' target='_blank'>Plupload</a>, your ultimate upload solution featuring HTML5 upload support.</p>
                    <p>Thanks for supporting TinyMCE! We hope it helps you and your users create great content.<br />All the best from the TinyMCE team.</p>";
        }

        private static string GetCover1()
        {
            /*return @"<div align='center'><strong>MARTIN STEIN</strong><br />15 Applegate Way <br />Sometown, PA 19000<br />(215) 555-5555<br />martinstein@somedomain.com<br /><br />&nbsp;</div>
<p>{Date}<br /><br />{Contact First Name} {Contact Last Name}<br />{Contact Position}<br /><b>{Company Name}</b><br />{Contact Address}<br /><br />Dear {Contact Name Prefix} {Contact Last Name},<br /><br />Are you searching for a <b>{Job Title}</b>&nbsp;with a proven ability to develop high-performance applications and technical innovations? If so, please consider my enclosed resume.<br /><br />Since 2010, I have served as a software engineer for Some Company, where I have been repeatedly recognized for developing innovative solutions for multimillion-dollar, globally deployed software and systems. I am responsible for full lifecycle development of next-generation software, from initial requirement gathering to design, coding, testing, documentation and implementation. <br /><br />Known for excellent client-facing skills, I have participated in proposals and presentations that have landed six-figure contracts. I also excel in merging business and user needs into high-quality, cost-effective design solutions while keeping within budgetary constraints.<br /><br />My technical expertise includes cross-platform proficiency ({Operating Systems, eg: Windows, Linux}); fluency in 13 scripting/programming languages (including {programming language, eg: C, C++}); and advanced knowledge of developer applications, tools, methodologies and best practices (including OOD, client/server architecture and self-test automation).<br /><br />My experience developing user-friendly solutions on time and on budget would enable me to step into a software engineering role at <b>{Company Name}</b>&nbsp;and hit the ground running. I will follow up with you next week, and you may reach me at (215) 555-5555. I look forward to speaking with you.<br /><br />Sincerely,<br /><br /><br /><br />Martin Stein<br /><br />Enclosure</p>";*/
            return @"&lt;div align='center'&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;&lt;strong&gt;MARTIN STEIN&lt;/strong&gt;&lt;/span&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;15 Applegate Way &lt;/span&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;Sometown, PA 19000&lt;/span&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;(215) 555-5555&lt;/span&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;martinstein@somedomain.com&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;&amp;nbsp;&lt;/span&gt;&lt;/div&gt;&lt;p&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;{Date}&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;{Contact First Name} {Contact Last Name}&lt;/span&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;{Contact Position}&lt;/span&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;&lt;strong&gt;{Company Name}&lt;/strong&gt;&lt;/span&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;{Contact Address}&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;Dear {Contact Name Prefix} {Contact Last Name},&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;Are you searching for a &lt;strong&gt;{Job Title}&lt;/strong&gt;&amp;nbsp;with a proven ability to develop high-performance applications and technical innovations? If so, please consider my enclosed resume.&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;Since 2010, I have served as a software engineer for Some Company, where I have been repeatedly recognized for developing innovative solutions for multimillion-dollar, globally deployed software and systems. I am responsible for full lifecycle development of next-generation software, from initial requirement gathering to design, coding, testing, documentation and implementation. &lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;Known for excellent client-facing skills, I have participated in proposals and presentations that have landed six-figure contracts. I also excel in merging business and user needs into high-quality, cost-effective design solutions while keeping within budgetary constraints.&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;My technical expertise includes cross-platform proficiency ({Operating Systems, eg: Windows, Linux}); fluency in 13 scripting/programming languages (including {programming language, eg: C, C++}); and advanced knowledge of developer applications, tools, methodologies and best practices (including OOD, client/server architecture and self-test automation).&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;My experience developing user-friendly solutions on time and on budget would enable me to step into a software engineering role at &lt;strong&gt;{Company Name}&lt;/strong&gt;&amp;nbsp;and hit the ground running. I will follow up with you next week, and you may reach me at (215) 555-5555. I look forward to speaking with you.&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;Sincerely,&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;Martin Stein&lt;/span&gt;&lt;br /&gt;&lt;br /&gt;&lt;span style='font-family: arial, helvetica, sans-serif;'&gt;Enclosure&lt;/span&gt;&lt;/p&gt;";
        }

        private static string GetMyCover()
        {
            return @"&lt;div style='text-align: justify;'&gt;&lt;span style='font-size: 14pt; font-family: Tahoma, Geneva, sans-serif;'&gt;&lt;strong&gt;Ajith &lt;/strong&gt;&lt;span style='font-weight: 400;'&gt;Vimalchand&lt;/span&gt;&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;1216 E Vista Del Cerro Dr. Apt #2009, Tempe, AZ - 85281 | 4803267284 | avimalch@asu.edu&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;{Date}&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;{Recipient Name}&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;{Title}&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;{Company}&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;{Address}&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;{City, ST &amp;nbsp;ZIP Code}&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;Dear [Recipient]:.&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;I am very interested in working with a {adj}, {adj} company such as {Company Name}. I found projects like {Name something that they are working on} appealing as they coincide with my career goals, and I am keen on contributing to this company as a {Position name}.&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;I am a Computer Science graduate student at Arizona State University, currently working as a Software Developer Intern for Axosoft, LLC. I have previously worked in Bosch, India for forty one months, as mentioned in my resume.&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;&lt;span style='font-weight: 400;'&gt;In over three years of work experience that I have had as a &lt;/span&gt;&lt;strong&gt;Full Stack Developer&lt;/strong&gt;&lt;span style='font-weight: 400;'&gt;, I have mastered different programming languages and technologies like {Name 3/4 languages/technologies}. As a Senior Software Engineer in Bosch, India, I learnt to design, develop and maintain software efficiently in &lt;/span&gt;&lt;strong&gt;C#&lt;/strong&gt;&lt;span style='font-weight: 400;'&gt;, with my emphasis on client satisfaction. My ideas were appreciated and I was awarded the Star Performer in the company for that year. I have also been a .Net Web Developer in Arizona State University where I redesigned legacy websites to tune performance and improve usability of university&amp;rsquo;s web applications.&lt;/span&gt;&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;&lt;span style='font-weight: 400;'&gt;I am also passionate about coding in &lt;/span&gt;&lt;strong&gt;JavaScript&lt;/strong&gt;&lt;span style='font-weight: 400;'&gt;, Python and Java. I recently implemented a content based recommendation system called &amp;ldquo;Adaptive Quiz&amp;rdquo; in Java which enhances Adaptive learning among students. I designed and devised an algorithm to implement this system effectively. The project idea was relatively new and different from my other work, and it required me to brainstorm and analyze different solutions before formulating the best one. Presently, as a Software Developer Intern in Axosoft, LLC, I am developing a fast, &lt;/span&gt;&lt;strong&gt;responsive and scalable agile project development&lt;/strong&gt;&lt;span style='font-weight: 400;'&gt; tool for mobile using ReactJS, JavaScript and REST APIs.&lt;/span&gt;&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;&lt;span style='font-weight: 400;'&gt;I believe that my technical skills combined with my expertise would make me a suitable candidate for the {Position name} position in your company. Please feel free to contact me at &lt;/span&gt;&lt;strong&gt;avimalch@asu.edu&lt;/strong&gt;&lt;span style='font-weight: 400;'&gt; or &lt;/span&gt;&lt;strong&gt;+1 (480) 326 &amp;ndash; 7284&lt;/strong&gt;&lt;span style='font-weight: 400;'&gt; as per your convenience. Thank you for your time and consideration, and I look forward to hearing from you.&lt;/span&gt;&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&amp;nbsp;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;Sincerely,&lt;/span&gt;&lt;/div&gt;
&lt;div style='text-align: justify;'&gt;&lt;span style='font-weight: 400; font-size: 12pt; font-family: Tahoma, Geneva, sans-serif;'&gt;Ajith Vimalchand&lt;/span&gt;&lt;/div&gt;";
        }
    }
}