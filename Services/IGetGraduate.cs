using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Models;

namespace Project3_FinalExam.Services
{
    public interface IGetGraduate
    {
        Task<List<GradMajors>> GetGradDegrees();
    }
}
