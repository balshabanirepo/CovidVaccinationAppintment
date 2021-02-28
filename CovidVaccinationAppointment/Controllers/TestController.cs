using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ServicesClasseslibrary;

namespace CovidVaccinationAppointment.Controllers
{
    public class TestController : Controller
    {
        public IActionResult Index()
        {
            VaccinationTypeServicesClass vaccinationTypeServices = new VaccinationTypeServicesClass();
            vaccinationTypeServices.AddVaccinationType(new DataModel.VaccinationTypesDataModel { Name = "Fyzer" });
            vaccinationTypeServices.List();
            return View();
        }
    }
}