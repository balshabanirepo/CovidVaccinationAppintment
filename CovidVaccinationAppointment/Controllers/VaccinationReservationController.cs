using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataModel;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesClasseslibrary;
using Microsoft.AspNetCore.Mvc.Rendering;
namespace CovidVaccinationAppointment.Controllers
{
    public class VaccinationReservationController : Controller
    {
        private readonly RegistrarsServiceClass _registrarService;
        private readonly RegistrationObserver _registrationObserver;
        VaccinationTypeServicesClass _vaccinationTypeServicesClass;
       
        public VaccinationReservationController(IRegistrarServiceClass registrarService, IRegisrtationObserver regisrtationObserver
            ,IVaccinationTypeServicesClass vaccinationTypeServicesClass)
        {
            _registrarService = (RegistrarsServiceClass)registrarService;
            _registrationObserver = (RegistrationObserver)regisrtationObserver;
            _vaccinationTypeServicesClass = (VaccinationTypeServicesClass)vaccinationTypeServicesClass;
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
                List<VaccinationTypesDataModel> vaccinationTypes = _vaccinationTypeServicesClass.list();
                vaccinationTypes.Add(new VaccinationTypesDataModel { Id = 0, Name = "Please Select" });
                SelectList VaccinationTypes = new SelectList(vaccinationTypes, "Id", "Name","0");
               
                ViewBag.VaccinationTypes = VaccinationTypes;
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
            DateTime ReservationDateTime;
            ReservationDateTime = DateTime.ParseExact(appintmentDataModel.AppointmentDateAsString, "dd/MM/yyyy", new System.Globalization.CultureInfo("en-Us"));

            try

            { 
                if(ReservationDateTime.Date<DateTime.Now.Date)
                    {
                    throw new Exception("Reservation date should be less  than or equal to today's date");
                }
                if (!ModelState.IsValid)
                {
                    return View(appintmentDataModel);

                }
                List<string> RegistrarIds=   appintmentDataModel.RegistrarIds.Split(",".ToCharArray()[0]).ToList();
               
                List<VaccinationReservationDataModel> VaccinationReservations = (from id in RegistrarIds
                                                                    select new VaccinationReservationDataModel
                                                                    {
                                                                        RegistrarId = int.Parse(id),
                                                                        
                                                                    }).ToList();


                List<RegistrarsDataModel> registrars = (from id in RegistrarIds
                                                                    select new RegistrarsDataModel
                                                                    {
                                                                        Id = int.Parse(id),
                                                                        Notified=true

                                                                    }).ToList();
                foreach(RegistrarsDataModel registrars1 in registrars)
                {
                    _registrarService.MarkRegistrarsAsnotified(registrars1);
                }    
                
                TempData["SuccessFailueMessage"] = _registrationObserver.AddRegistrars(VaccinationReservations);
            }
            catch(Exception ex)
            {
                TempData["SuccessFailueMessage"]= ex.Message;
            }
            return RedirectToAction("AppointmentCreationComplete");
        }
        public ActionResult AppointmentCreationComplete()
        {
            ViewBag.SuccessFailueMessage = TempData["SuccessFailueMessage"];
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
