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
using ServicesClasseslibrary.API;

namespace CovidVaccinationAppointment.Controllers
{
    public class RegistrarsController : Controller
    {

        RegistrarsServiceClass _RegistrarsService = new RegistrarsServiceClass();

        public RegistrarsController(IRegistrarServiceClass RegistrarsService)
        {
            _RegistrarsService = (RegistrarsServiceClass)RegistrarsService;


        }

        // GET: RegistrarsRepositories
        public IActionResult Index()
        {
            return View(_RegistrarsService.List());
        }



        // GET: RegistrarsRepositories/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RegistrarsRepositories/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(RegistrarsDataModel model)
        {
            if (ModelState.IsValid)
            {
                _RegistrarsService.AddRegistrar(model);
                return RedirectToAction(nameof(Index));
            }
            return View(model);
        }

        // GET: RegistrarsRepositories/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrarsRepository = _RegistrarsService.GetById((Int32)id);
            if (registrarsRepository == null)
            {
                return NotFound();
            }
            return View(registrarsRepository);
        }

        // POST: RegistrarsRepositories/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit( RegistrarsDataModel registrarsRepository)
        {
            if (_RegistrarsService.GetById(registrarsRepository.Id)==null)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _RegistrarsService.EditRegistrar(registrarsRepository);

                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RegistrarsRepositoryExists(registrarsRepository.Id))
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
            return View(registrarsRepository);
        }

        // GET: RegistrarsRepositories/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var registrarsRepository = _RegistrarsService.GetById((Int32)(id));


            return View(registrarsRepository);
        }

        // POST: RegistrarsRepositories/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {

            _RegistrarsService.DeleteRegistrar(id);
            return RedirectToAction(nameof(Index));
        }

        private bool RegistrarsRepositoryExists(int id)
        {
            return _RegistrarsService.GetById((Int32)(id)) != null;
        }

        public async Task<ActionResult> CallTelephoneGeneratorFunction(string Number)
        {
            IdCheckAPICaller _IdCheckAPICaller = new IdCheckAPICaller();
            _IdCheckAPICaller.Number = Number;

            string responeData;
            try
            {
                    responeData = await _IdCheckAPICaller.CallAPI();

                return Json(new { success = _IdCheckAPICaller.response, data = responeData });

            }
            catch (Exception ex)
            {
                return Json(new { success = false, data = ex.Message });
            }

        }
    }
}
