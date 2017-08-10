using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using BugProj.Models;


namespace BugProj.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ILogger _logger;

        public AccountController(
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IOptions<IdentityCookieOptions> identityCookieOptions,

            ILoggerFactory loggerFactory)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = loggerFactory.CreateLogger<AccountController>();
            
        }

        [HttpGet("[action]")]
        public IActionResult MyTest(){
            string Hello = "Hello";
            Hello = "World";
            string a = Hello;
            return Json(a);
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            model.RememberMe = false;
        
            if(ModelState.IsValid)
            {
                try{
                var result = await _signInManager.PasswordSignInAsync(
                    model.Email, model.Password, model.RememberMe, lockoutOnFailure: false);
                if(result.Succeeded)
                {
                    return Ok();
                }
                else{
                    return new BadRequestResult();
                }
                }
                catch(Exception e)
                {
                    string mes = e.Message;
                    string lol = mes;
                }
            }   

            return  new BadRequestResult();

        }
        //[HttpGet("[action]")]
        [HttpPost]
        public async Task<ActionResult> Register([FromBody]RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser { 
                    UserName = model.Email, 
                    Email = model.Email,
                    CompanyID = model.CompanyID,
                    FName = model.FName,
                    MI = model.MI,
                    LName = model.LName,
                    Alias = model.Alias,
                    Pic = model.Pic,
                    UserType = model.UserType
                     };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
                    // Send an email with this link
                    try{
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        _logger.LogInformation(3, "User created a new account with password.");
                        return new OkResult();
                    }
                    catch(Exception e)
                    {
                        string message = e.Message;
                        return new OkResult();
                    } 
                }
                AddErrors(result);
                return new BadRequestResult();
            }
            return new BadRequestResult();
            // If we got this far, something failed, redisplay form
            //return View(model);
        }

        private static void NewMethod(Exception e)
        {
            string ex = e.Message;
        }

        // public async Task<ActionResult> Post(RegisterViewModel model)
        // {
        //     if (ModelState.IsValid)
        //     {
        //         var user = new ApplicationUser { UserName = model.Email, Email = model.Email };
        //         var result = await _userManager.CreateAsync(user, model.Password);
        //         if (result.Succeeded)
        //         {
        //             // For more information on how to enable account confirmation and password reset please visit https://go.microsoft.com/fwlink/?LinkID=532713
        //             // Send an email with this link
        //             await _signInManager.SignInAsync(user, isPersistent: false);
        //             _logger.LogInformation(3, "User created a new account with password.");
        //             //return RedirectToLocal(returnUrl);
        //         }
        //         AddErrors(result);
        //         return new BadRequestResult();
        //     }
        //     return new BadRequestResult();
        //     // If we got this far, something failed, redisplay form
        //     //return View(model);
        // }

        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }
        }
    
    }
}