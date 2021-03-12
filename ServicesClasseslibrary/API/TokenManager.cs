using DataModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

 namespace ServicesClasseslibrary.API
{
   public class TokenManager
    {
        string apiUrlForTokenRetrieve = "http://localhost:65501/api/Home/CheckToken";
        SystemSettingsServiceClass SystemSettingsServiceClass = new SystemSettingsServiceClass();

        public string Token { get; set; }

        //private UnitOfWork unitOfWork;

        //Model.SystemConfiguration systemConfiguration;
        public void ReadTokenValueFromDb()
        {

          SystemSettingsDataModel settingsDataModel=  SystemSettingsServiceClass.GetSystemSettings();
            if (settingsDataModel != null)
            {
                Token = settingsDataModel.Token;
            }
        }

        public async Task<bool> CheckIfTokenExpired()
        {


            string apiUrlForPractionerIdCheck = "http://localhost:65501/api/TelephoneDirectories/PhoneByNumber";

            HttpClient client = new HttpClient();
            client = new HttpClient();

            client.BaseAddress = new Uri(apiUrlForPractionerIdCheck);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            client.DefaultRequestHeaders.Add("Authorization", "Bearer " + Token);

            var RequestObject = JsonConvert.SerializeObject(new

            //    HPISRequest


            //    ServiceKey= "SCFHS"

            //,
            //    PractitionerIdentity = newPractitionerIdentity
            {
                Number = "Number",
                IDValue = "1111"
            });

            HttpResponseMessage response = await client.PostAsync(apiUrlForPractionerIdCheck+ "?Number=0000",new StringContent(""));
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



            responeDataConverted = JsonConvert.DeserializeObject<Dictionary<string, string>>(responeData);


            Token = responeDataConverted["access_token"];
            updateDbTokenField();
            return Token;
          
        }


    }
}

