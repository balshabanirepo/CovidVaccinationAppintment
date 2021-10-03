using ServicesClasseslibrary.API;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServicesClasseslibrary.API
{
    public abstract class MainAPICaller
    {
       private TokenManager tokenManager;

        public ISystemSettingsServiceClass systemSettingsServiceClass { get; set; }
        protected async Task PrepareToken()
        {
            tokenManager = new TokenManager { systemSettingsServiceClass = systemSettingsServiceClass };
          
            tokenManager.ReadTokenValueFromDb();
            //if (await tokenManager.CheckIfTokenExpired())
            //{

                await tokenManager.GenerateNewToken();
            //}
           
            Token = tokenManager.Token;

        }


        protected string _apiUrl = "";
        protected string Token = "";
        //public abstract Task CheckToken();


        public abstract Task<string> CallAPI();
        public HttpResponseMessage response { get; set; }




    }
}
