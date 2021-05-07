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
    public class GetGraduate
    {
        public async Task<List<GradMajors>> GetGradDegrees()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/degrees/graduate", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<GradMajors>>>(data);
                    List<GradMajors> gradList = new List<GradMajors>();
                    GradMajors gradMajors = new GradMajors();

                    foreach (KeyValuePair<string, List<GradMajors>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            gradList.Add(item);
                        }
                    }

                    return gradList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<GradMajors> gradMajorsList = new List<GradMajors>();
                    return gradMajorsList;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<GradMajors> gradMajorsList = new List<GradMajors>();
                    return gradMajorsList;
                }
            }
        }
    }
}
