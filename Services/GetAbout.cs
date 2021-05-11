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
    public class GetAbout : IGetAbout
    {
        public async Task<AboutInfo> GetAboutInfo()
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

                    var rtnResults = JsonConvert.DeserializeObject<AboutInfo>(data);

                    return rtnResults;

                }
                catch (HttpRequestException hre)
                {
                    var msg = hre.Message;
                    AboutInfo aboutInfo = new AboutInfo();
                    return aboutInfo;
                }
                catch (Exception ex)
                {
                    var msg = ex.Message;
                    AboutInfo aboutInfo = new AboutInfo();
                    return aboutInfo;
                }
            }
        }
    }
}
