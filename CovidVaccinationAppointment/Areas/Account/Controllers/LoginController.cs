using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CovidVaccinationAppointment.Controllers
{
    [Area("Account")]
    public class LoginController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly ILogger<DataModel.LoginDataModel> _logger;
        public LoginController(SignInManager<IdentityUser> signInManager,
            ILogger<DataModel.LoginDataModel> logger,
            UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
           
            _logger = logger;

        }
        [HttpPost]
        public async Task<ActionResult> Login(DataModel.LoginDataModel Input, string returnUrl = null)


        {
            returnUrl = returnUrl ?? Url.Content("~/");


            // This doesn't count login failures towards account lockout
            // To enable password failures to trigger account lockout, set lockoutOnFailure: true


            if (ModelState.IsValid)
            {
                // This doesn't count login failures towards account lockout
                // To enable password failures to trigger account lockout, set lockoutOnFailure: true
                var result = await _signInManager.PasswordSignInAsync(Input.Email, Input.Password, Input.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    _logger.LogInformation("User logged in.");
                    return LocalRedirect(returnUrl);
                }
               
                else
                {
                    ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                    return View();
                }
            }

            // If we got this far, something failed, redisplay form
            return View();
        }
        [HttpGet]
        public async Task<ActionResult> Login(string returnUrl = "/")
        {
            return View();
        }

        // If we got this far, something failed, redisplay form

    }
    
}
