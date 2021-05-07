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
    public class GetAbout
    {
        public async Task<List<AboutInfo>> GetAboutInfo()
        {
            using (var client1 = new HttpClient())
            {
                client1.BaseAddress = new Uri("http://www.ist.rit.edu/");
                client1.DefaultRequestHeaders.Accept.Clear();
                client1.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                try
                {
                    HttpResponseMessage response = await client1.GetAsync("api/about", HttpCompletionOption.ResponseHeadersRead);
                    response.EnsureSuccessStatusCode();
                    var data = await response.Content.ReadAsStringAsync();

                    // Above three lines can be replaced with new helper method below
                    // string responseBody = await client.GetStringAsync(uri);

                    var rtnResults = JsonConvert.DeserializeObject<Dictionary<string, List<AboutInfo>>>(data);
                    List<AboutInfo> aboutInfoList = new List<AboutInfo>();

                    foreach (KeyValuePair<string, List<AboutInfo>> kvp in rtnResults)
                    {
                        foreach (var item in kvp.Value)
                        {
                            aboutInfoList.Add(item);
                        }
                    }

                    return aboutInfoList;



                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    List<AboutInfo> aboutInfo = new List<AboutInfo>();
                    return aboutInfo;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    List<AboutInfo> aboutInfo = new List<AboutInfo>();
                    return aboutInfo;
                }
            }
        }
    }
}
