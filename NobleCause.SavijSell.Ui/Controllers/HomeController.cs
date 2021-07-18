using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NobleCause.SavijSell.Ui.Models;
using NobleCause.SavijSell.Ui.Services;
using NobleCause.SavijSell.Ui.ViewModels;
using System.Diagnostics;

namespace NobleCause.SavijSell.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductsService _productsService;

        public HomeController(ILogger<HomeController> logger,
                              IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        public IActionResult Index()
        {
            // call service
            //var products = _productsService.GetProducts();
            // 
            // 
            var viewModel = new HomeViewModel
            {
                Products = _productsService.GetProducts()
            };

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
