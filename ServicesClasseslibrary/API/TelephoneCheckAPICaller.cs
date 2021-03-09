using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        string responseData;
        await this.CheckToken();
        HttpClient client = new HttpClient();
       
        client.BaseAddress = new Uri(_apiUrl);
          
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
