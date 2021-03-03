using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesClasseslibrary;

namespace CovidVaccinationAppointment.Controllers
{
    public class VaccinationReservationController : Controller
    {
        private readonly RegistrarsServiceClass _registrarService;
        public VaccinationReservationController(IRegistrarServiceClass registrarService)
        {
            _registrarService = (RegistrarsServiceClass)registrarService;
        }
        // GET: VaccinationReservationController
        public ActionResult RegistrarSearch()
        {

            return View(new RegistrarSearchDataModel {SearchText="", Registrars = new List<RegistrarsDataModel>() });
        }

        // GET: VaccinationReservationController/Details/5
      

        // GET: VaccinationReservationController/Create
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ExecuteRegistrarSearch(RegistrarSearchDataModel registrarSearchDataModel)
        {
            try
            {

                registrarSearchDataModel.Registrars = _registrarService.List().Where(w => w.Name.Contains(registrarSearchDataModel.SearchText) || w.Name.Contains(registrarSearchDataModel.SearchText)).ToList();
                return View("RegistrarSearch", registrarSearchDataModel);
            }
            catch
            {
                return View();
            }
        }

        // POST: VaccinationReservationController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(VaccinationReservationDataModel vaccinationReservation)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VaccinationReservationController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VaccinationReservationController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(VaccinationReservationDataModel vaccinationReservation)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VaccinationReservationController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VaccinationReservationController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(VaccinationReservationDataModel vaccinationReservation)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
