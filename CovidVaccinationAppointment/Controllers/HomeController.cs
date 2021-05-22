using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using CovidVaccinationAppointment.Models;
using ServicesClasseslibrary;
using DataModel;

namespace CovidVaccinationAppointment.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVaccinationTypeServicesClass _vaccinationTypeServices;


        public HomeController(ILogger<HomeController> logger,IVaccinationTypeServicesClass vaccinationTypeServices)
        { 
            _logger = logger;
            _vaccinationTypeServices = vaccinationTypeServices;
        }



        public IActionResult Index()
        {
            //VaccinationTypeServicesClass vaccinationTypeServices = new VaccinationTypeServicesClass();
            // vaccinationTypeServices.AddVaccinationType(new DataModel.VaccinationTypesDataModel { Name = "Fyzer" });
            _vaccinationTypeServices.list();
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
