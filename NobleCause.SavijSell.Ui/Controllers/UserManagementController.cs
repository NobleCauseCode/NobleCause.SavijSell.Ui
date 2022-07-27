using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NobleCause.SavijSell.Ui.Models;
using NobleCause.SavijSell.Ui.Services;
using NobleCause.SavijSell.Ui.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Controllers
{
    public class UserManagementController : Controller
    {
        private readonly IUserManagementService _userManagementService;

        public UserManagementController(IUserManagementService userManagementService)
        {
            _userManagementService = userManagementService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ConfirmationReminder()
        {
            return View("ConfirmationReminder");
        }

        public IActionResult SignUp()
        {
            var viewModel = new SignUpViewModel();

            return View("SignUp", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> SignUpPost(SignUpViewModel viewModel)
        {
            // insert viewModel data to the api (db)
            // redirect to ConfirmationReminder
            await _userManagementService.SignUp(viewModel.FirstName, viewModel.LastName,
                                                viewModel.Email, viewModel.Password,
                                                viewModel.UserName, viewModel.PostalCode);

            return RedirectToAction("ConfirmationReminder");
        }

        [HttpPost]
        [ActionName("LoginPostAsync")]
        public async Task<IActionResult> LoginPostAsync(LoginViewModel viewModel)
        {
            var tokenResponse = await _userManagementService
                                .LoginAsync(viewModel.Email, viewModel.Password);
            Response.Cookies.Append(
                Constants.XAccessToken,
                tokenResponse.Token, new CookieOptions
                {
                    HttpOnly = true,
                    SameSite = SameSiteMode.Strict
                });
            return RedirectToAction("Index", "Products");
        }

        [Route("VerifyEmail/{verificationData}")]
        public async Task<IActionResult> VerifyEmail( string verificationData)
        {
            var verified =  await _userManagementService.VerifyEmail(verificationData);
            if(verified)
            {
                return View("EmailVerified");
            }

            return View("VerifyFailed");
            
        }
    }
}
