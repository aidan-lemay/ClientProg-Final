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
    public class GetStaff : IGetStaff
    {
        public async Task<List<Staff>> GetAllStaff()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                try
                {
                    HttpResponseMessage response = await client.GetAsync("api/people/staff", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<Staff>>>(data);

                    List<Staff> staffList = new List<Staff>();
                    Staff staff = new Staff();

                    foreach (KeyValuePair<string, List<Staff>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            staffList.Add(item);
                        }
                    }

                    return staffList;
                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<Staff> staffList = new List<Staff>();
                    return staffList;
                    //return "HttpRequestException";
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<Staff> staffList = new List<Staff>();
                    return staffList;
                    //return "Exception"; ;
                }
            }
        }
    }
}
