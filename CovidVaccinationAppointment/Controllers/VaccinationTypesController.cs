using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DataModel;
using ServicesClasseslibrary;

namespace CovidVaccinationAppointment.Controllers
{
    public class VaccinationTypesController : Controller
    {
        private readonly ServicesClasseslibrary.VaccinationTypeServicesClass vaccinationTypeServices ;

        public VaccinationTypesController(IVaccinationTypeServicesClass VaccinationTypeServices)
        {
            vaccinationTypeServices =(VaccinationTypeServicesClass) VaccinationTypeServices;
        }

        // GET: VaccinationTypes
        public IActionResult Index()
        {
            return View(vaccinationTypeServices.List());
        }

        // GET: VaccinationTypes/Details/5
       

        // GET: VaccinationTypes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: VaccinationTypes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("Id,Name")] VaccinationTypesDataModel vaccinationType)
        {
            if (ModelState.IsValid)
            {
                vaccinationTypeServices.AddVaccinationType(vaccinationType);

                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationType);
        }

        // GET: VaccinationTypes/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var vaccinationTypesRepository = vaccinationTypeServices.GetById((int)id);
            if (vaccinationTypesRepository == null)
            {
                return NotFound();
            }
            return View(vaccinationTypesRepository);
        }

        // POST: VaccinationTypes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(VaccinationTypesDataModel vaccinationType)
        {
           
            if (ModelState.IsValid)
            {
                try
                {
                    vaccinationTypeServices.EditVaccinationType(vaccinationType);
                   
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VaccinationTypesRepositoryExists(vaccinationType.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(vaccinationType);
        }

        // GET: VaccinationTypes/Delete/5
        public IActionResult Delete(int? id)
        {
            
            if (id == null)
            {
                return NotFound();
            }

            VaccinationTypesDataModel model = vaccinationTypeServices.GetById((int) id);

            return View(model);
        }

        // POST: VaccinationTypes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            VaccinationTypesDataModel model = vaccinationTypeServices.GetById((int)id);
            vaccinationTypeServices.DeleteVaccinationType(id);

            return RedirectToAction(nameof(Index));
        }

        private bool VaccinationTypesRepositoryExists(int id)
        {
            return vaccinationTypeServices.GetById(id) != null;

        }
    }
}
