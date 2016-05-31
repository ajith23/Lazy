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
            list.Add(new Cover { Id = 1, UserId = 1, Version = "V 1", Template = GetDummyTemplate() });
            list.Add(new Cover { Id = 2, UserId = 1, Version = "V 2", Template = GetDummyTemplate() });
            list.Add(new Cover { Id = 3, UserId = 1, Version = "V 3", Template = GetDummyTemplate() });
            return list;
        }

        private static string GetDummyTemplate()
        {
            return @"<p style='text-align: center; font-size: 15px;'><img title='TinyMCE Logo' src='//www.tinymce.com/images/glyph-tinymce@2x.png' alt='TinyMCE Logo' width='110' height='97' /></p>
                    <h1 style='text-align: center;'>Welcome to the TinyMCE editor demo!</h1>
                    <p>Please try out the features provided in this full featured example.</p>
                    <p>Note that any <strong>MoxieManager</strong> file and image management functionality in this example is part of our commercial offering &ndash; the demo is to show the integration.</p>
                    <h2>Got questions or need help?</h2>
                    <ul>
                    <li>Our <a href='//www.tinymce.com/docs/'>documentation</a> is a great resource for learning how to configure TinyMCE.</li>
                    <li>Have a specific question? Visit the <a href='http://community.tinymce.com/forum/'>Community Forum</a>.</li>
                    <li>We also offer enterprise grade support as part of <a href='http://tinymce.com/pricing'>TinyMCE Enterprise</a>.</li>
                    </ul>
                    <h2>A simple table to play with</h2>
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
    }
}