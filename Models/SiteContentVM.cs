using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GetSiteContent.Models
{
    public class SiteContentVM
    {
        public List<string> Pictures { get; set; }
        public List<WordCount> SiteWords { get; set; }
    }
}