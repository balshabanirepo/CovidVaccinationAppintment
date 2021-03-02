using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClasseslibrary.API
{
    public class IdCheckAPICaller:API.MainAPICaller
    { 
    public IdCheckAPICaller()
    {

        _apiUrl = "http://localhost:65501/api/TelephoneDirectories/PhoneByNumber";

    }

    public string Number { get; set; }
    public override async Task<string> CallAPI()
    {
        string responseData;
        //await this.CheckToken();
        HttpClient client = new HttpClient();
        //client = new HttpClient();

        client.BaseAddress = new Uri(_apiUrl);
            //client.DefaultRequestHeaders.Accept.Clear();
            //client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            //client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

            var RequestObject = JsonConvert.SerializeObject(new

            //    HPISRequest


            //    ServiceKey= "SCFHS"

            //,
            //    PractitionerIdentity = newPractitionerIdentity
            {
                
                Number = Number
            });

            HttpResponseMessage response = await client.GetAsync(_apiUrl+ "?Number="+ Number);

        this.response = response;

        responseData = await response.Content.ReadAsStringAsync();
        return responseData;
    }

    public override async Task CheckToken()
    {
        await base.PrepareToken();
    }
}
}
