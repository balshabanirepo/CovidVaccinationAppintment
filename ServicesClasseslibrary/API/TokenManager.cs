using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

 namespace ServicesClasseslibrary.API
{
   public class TokenManager
    {
        string apiUrlForTokenRetrieve = "http://localhost:65501/api/Home/GenerateNewToken";
        //SystemSettingsOperationsClass SystemSettingsServiceClass = new SystemSettingsOperationsClass();
        public ISystemSettingsServiceClass systemSettingsServiceClass { get; set; }
        public string Token { get; set; }

        //private UnitOfWork unitOfWork;

        //Model.SystemConfiguration systemConfiguration;
        public void ReadTokenValueFromDb()
        {
            SystemSettingsDataModel settingsDataModel=  systemSettingsServiceClass.GetSystemSettings();


            if (settingsDataModel != null)
            {
                Token = settingsDataModel.Token;
            }
        }

        public async Task<bool> CheckIfTokenExpired()
        {

            if(Token==null)
            {
                return true;
            }
            string apiUrl = "http://localhost:65501/api/TelephoneDirectories/PhoneByNumber";

            HttpClient client = new HttpClient();
            client = new HttpClient();

            client.BaseAddress = new Uri(apiUrl);


           

           

            
          
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, apiUrl + "?Number=0000" );

            request.Headers.Authorization = new AuthenticationHeaderValue("Token", Token);

          
            HttpResponseMessage response =  await client.SendAsync(request);
            return response.StatusCode == System.Net.HttpStatusCode.Unauthorized;





        }

        public void updateDbTokenField()
        {
            try
            {
                SystemSettingsDataModel systemSettingsDataModel = new SystemSettingsDataModel { Token = Token };
                systemSettingsServiceClass.SaveSystemSettings(systemSettingsDataModel);
            }

            catch (Exception ex)
            {

            }

        }
        public async Task<string> GenerateNewToken()
        {
            string responeData = "";
            Dictionary<string, string> responeDataConverted;
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(apiUrlForTokenRetrieve);



            //var RequestObject = new Dictionary<string, string>();
            //RequestObject.Add("grant_type", "client_credentials");



            var RequestObject = JsonConvert.SerializeObject(

            //    HPISRequest


            //    ServiceKey= "SCFHS"

            //,
               new 
               {

                userName = "JPhontain",
                Password= "A@67b12345"
            });



            HttpResponseMessage response = await client.PostAsync(client.BaseAddress, new StringContent(RequestObject, System.Text.Encoding.UTF8, "application/json"));




            responeData = await response.Content.ReadAsStringAsync();



            //responeDataConverted = JsonConvert.DeserializeObject<Dictionary<string, string>>(responeData);


            // Token = responeDataConverted["token"];
           //Token = responeData.Substring(10, responeData.Substring(10).IndexOf(",") - 2);
           Token = responeData.Substring(0);
            updateDbTokenField();
            return Token;
          
        }


    }
}

