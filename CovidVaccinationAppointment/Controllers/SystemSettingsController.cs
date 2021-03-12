using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataRepository;
using DataRepository.GateWay;
using ServicesClasseslibrary;
using DataModel;

namespace CovidVaccinationAppointment.Controllers
{
    public class SystemSettingsController : Controller
    {
        private readonly ServicesClasseslibrary.SystemSettingsServiceClass _SystemSettingsServiceClass;

        public SystemSettingsController(ISystemSettingsServiceClass systemSettingsService)
        {
            _SystemSettingsServiceClass = (SystemSettingsServiceClass)systemSettingsService;
        }

        // GET: SystemSettings
     

        // GET: SystemSettings/Details/5
       

        // GET: SystemSettings/Create
        public IActionResult Save()
        {
         SystemSettingsDataModel systemSettings=   _SystemSettingsServiceClass.GetSystemSettings();

            return View(systemSettings);
        }

        // POST: SystemSettings/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Save(SystemSettingsDataModel systemSettingsDataModel)
        {
            if (ModelState.IsValid)
            {
                _SystemSettingsServiceClass.SaveSystemSettings(systemSettingsDataModel);
                return RedirectToAction("Index", "Home");

            }
            return View(systemSettingsDataModel);
        }

      

        
    }
}
