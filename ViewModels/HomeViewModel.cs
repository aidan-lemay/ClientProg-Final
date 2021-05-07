using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Models;

namespace Project3_FinalExam.ViewModels
{
    public class HomeViewModel
    {
        public List<AboutInfo> AboutInfo { get; set; }
        public List<Faculty> Faculty { get; set; }
        public List<Staff> Staff { get; set; }
        public string Title { get; set; }
    }
}
