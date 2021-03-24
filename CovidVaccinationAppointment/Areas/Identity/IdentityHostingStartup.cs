using System;
//using CovidVaccinationAppointment.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using DataRepository.GateWay;
using Microsoft.AspNetCore.Authentication.Cookies;

[assembly: HostingStartup(typeof(CovidVaccinationAppointment.Areas.Identity.IdentityHostingStartup))]
namespace CovidVaccinationAppointment.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<DbConext>();

                //services.AddIdentityCore<IdentityUser>()
                //    .AddEntityFrameworkStores<DbConext>();

                //services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
                // .AddCookie();
            });
        }   
    }
}