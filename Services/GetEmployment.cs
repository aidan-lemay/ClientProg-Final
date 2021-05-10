using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Project3_FinalExam.Models;
using System.Net.Http;
using System.Net.Http.Headers;
using Newtonsoft.Json;

namespace Project3_FinalExam.Services
{
    public class GetEmployment
    {
        public async Task<List<EmploymentTable>> GetEmploymentTable()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/employment/employmentTable/professionalEmploymentInformation", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<EmploymentTable>>>(data);
                    List<EmploymentTable> employmentList = new List<EmploymentTable>();

                    foreach (KeyValuePair<string, List<EmploymentTable>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            employmentList.Add(item);
                        }
                    }

                    return employmentList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<EmploymentTable> employmentList = new List<EmploymentTable>();
                    return employmentList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<EmploymentTable> employmentList = new List<EmploymentTable>();
                    return employmentList;
                }
            }
        }
    }
}
