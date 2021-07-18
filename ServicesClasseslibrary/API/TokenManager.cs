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

        public string Token { get; set; }

        //private UnitOfWork unitOfWork;

        //Model.SystemConfiguration systemConfiguration;
        public void ReadTokenValueFromDb()
        {

          //SystemSettingsDataModel settingsDataModel=  SystemSettingsServiceClass.GetSystemSettings();
          //  if (settingsDataModel != null)
          //  {
          //      Token = settingsDataModel.Token;
          //  }
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
            client.DefaultRequestHeaders.Authorization =
new AuthenticationHeaderValue("Bearer", Token);

            var RequestObject = JsonConvert.SerializeObject(new

            //    HPISRequest


            //    ServiceKey= "SCFHS"

            //,
            //    PractitionerIdentity = newPractitionerIdentity
            {
                Number = "Number",
                IDValue = "1111"
            });

            HttpResponseMessage response = await client.PostAsync(apiUrl+ "?Number=0000",new StringContent(""));
            return !response.IsSuccessStatusCode;





        }

        public void updateDbTokenField()
        {
            //if (systemConfiguration == null)
            //{
            //    return;
            //}
            //try
            //{
            //    systemConfiguration.APIToken = Token;
            //    unitOfWork.SystemConfigurationRepository.Update(systemConfiguration);
            //    unitOfWork.Save();
            //}
            //catch (Exception ex)
            //{

            //}

        }
        public async Task<string> GenerateNewToken()
        {
            string responeData = "";
            string tokenstring;
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
            tokenstring = responeData.Substring(10, responeData.Substring(10).IndexOf(",") - 2);
            Token = responeData;
            updateDbTokenField();
            return Token;
          
        }


    }
}

