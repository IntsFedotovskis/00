using System.Collections.Generic;
using Microsoft.VisualBasic;

namespace _00.Models
{
    public class Holiday
    {
        public string Date { get; set; }
        public string LocalName { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public bool Fixed { get; set; }
        public bool Global { get; set; }
        public object Counties { get; set; }
        public object LaunchYear { get; set; }
        public string Type { get; set; }
    }
}