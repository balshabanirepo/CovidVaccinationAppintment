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
        string apiUrlForPractionerTokenRetrieve = "https://epns.scfhs.org.sa/token";


        public string Token { get; set; }

        //private UnitOfWork unitOfWork;

        //Model.SystemConfiguration systemConfiguration;
        public void ReadTokenValueFromDb()
        {

            //unitOfWork = new UnitOfWork();
            //systemConfiguration = unitOfWork.SystemConfigurationRepository.AllQueryable().ToList().FirstOrDefault();

            //if (systemConfiguration != null)
            //{
            //    Token = systemConfiguration.APIToken;

            //}

        }

        public async Task<bool> CheckIfTokenExpired()
        {


            string apiUrlForPractionerIdCheck = "https://prdgta.scfhs.org.sa/practitioner/profile/rst/1.0.0";

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
                IDName = "RegistrationNumber",
                IDValue = "1111"
            });

            HttpResponseMessage response = await client.PostAsync(apiUrlForPractionerIdCheck, new
           StringContent(RequestObject, Encoding.UTF8, "application/json"));
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
            client.BaseAddress = new Uri(apiUrlForPractionerTokenRetrieve);

            client.DefaultRequestHeaders.Add("Authorization", "Basic ekl6bFVWYWdzR3RBSDJ4R25UY2tJeXk5cDFBYTpmT2RkNG9RRjBma0FRUDRFcUc5VHN3UktrSklh");

            var RequestObject = new Dictionary<string, string>();
            RequestObject.Add("grant_type", "client_credentials");


            HttpResponseMessage response = await client.PostAsync(apiUrlForPractionerTokenRetrieve, new FormUrlEncodedContent(RequestObject));


            responeData = await response.Content.ReadAsStringAsync();



            responeDataConverted = JsonConvert.DeserializeObject<Dictionary<string, string>>(responeData);


            Token = responeDataConverted["access_token"];
            updateDbTokenField();
            return Token;
          
        }


    }
}

