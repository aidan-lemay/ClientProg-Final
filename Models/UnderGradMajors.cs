using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Project3_FinalExam.Models
{
    public class UnderGradMajors
    {
        public string degreeName { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public List<string> concentrations { get; set; }
    }
}
