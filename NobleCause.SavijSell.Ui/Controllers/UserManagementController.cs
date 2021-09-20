using Microsoft.AspNetCore.Mvc;
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
            await Task.CompletedTask;
            return RedirectToAction("ConfirmationReminder");
        }
    }
}
