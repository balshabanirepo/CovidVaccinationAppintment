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
        private readonly RegistrationObserver _registrationObserver;
       
        public VaccinationReservationController(IRegistrarServiceClass registrarService, IRegisrtationObserver regisrtationObserver)
        {
            _registrarService = (RegistrarsServiceClass)registrarService;
            _registrationObserver = (RegistrationObserver)regisrtationObserver;
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

                registrarSearchDataModel.Registrars = _registrarService.List().Where(w =>( w.Name.Contains(registrarSearchDataModel.SearchText) || w.Telephone.Contains(registrarSearchDataModel.SearchText))&&!w.Notified).ToList();
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
        public ActionResult Create(AppintmentDataModel appintmentDataModel)
        {
            try

            { 
             List<string> RegistrarIds=   appintmentDataModel.RegistrarIds.Split(",".ToCharArray()[0]).ToList();
                List<VaccinationReservationDataModel> registrars = (from id in RegistrarIds
                                                                    select new VaccinationReservationDataModel
                                                                    {
                                                                        RegistrarId = int.Parse(id),
                                                                        ReservationDateTime = appintmentDataModel.AppointmentDate

                                                                    }).ToList();

              

               ViewBag.SuccessFailueMessage = _registrationObserver.AddRegistrars(registrars);
            }
            catch(Exception ex)
            {
                ViewBag.SuccessFailueMessage = ex.Message;
            }
            return View();
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
