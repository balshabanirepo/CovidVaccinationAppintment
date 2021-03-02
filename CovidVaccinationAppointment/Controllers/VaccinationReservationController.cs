using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CovidVaccinationAppointment.Controllers
{
    public class VaccinationReservationController : Controller
    {
        // GET: VaccinationReservationController
        public ActionResult Index()
        {
            return View();
        }

        // GET: VaccinationReservationController/Details/5
      

        // GET: VaccinationReservationController/Create
        public ActionResult Create()
        {
            return View();
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
