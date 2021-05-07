using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Project3_FinalExam.ViewModels
{
    public class EmploymentTableViewModel
    {
        public List<EmploymentTable> employmentTable { get; set; }
        public string Title { get; set; }
    }
}
