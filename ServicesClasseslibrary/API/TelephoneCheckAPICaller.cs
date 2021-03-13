using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClasseslibrary.API
{
    public class TelephoneCheckAPICaller : API.MainAPICaller
    { 
    public TelephoneCheckAPICaller()
    {

        _apiUrl = "http://localhost:65501/api/TelephoneDirectories/PhoneByNumber";

    }

    public string Number { get; set; }
    public override async Task<string> CallAPI()
    {
           //await base.PrepareToken();
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json");

            var json = JsonConvert.SerializeObject(new
            {
                Number = Number
            });
       
          
           
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, _apiUrl + "?Number="+Number);
            //request.Headers.Authorization = new AuthenticationHeaderValue("Token", Token);

          this.response = await httpClient.SendAsync(request);

            var responeData = await response.Content.ReadAsStringAsync();
            return responeData;
        }

    
}
}
