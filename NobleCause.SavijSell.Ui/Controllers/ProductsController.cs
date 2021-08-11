using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NobleCause.SavijSell.Ui.Models;
using NobleCause.SavijSell.Ui.Services;
using NobleCause.SavijSell.Ui.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Controllers
{
    public class ProductsController : Controller
    {
        private readonly ILogger<ProductsController> _logger;
        private readonly IProductsService _productsService;

        public ProductsController(ILogger<ProductsController> logger,
                              IProductsService productsService)
        {
            _logger = logger;
            _productsService = productsService;
        }

        public async Task<IActionResult> Index()
        {
            // call service
            //var products = _productsService.GetProducts();
            // 
            // 
            var viewModel = new ProductsViewModel
            {
                Products = await _productsService.GetProducts()
            };

            return View(viewModel);
        }

        public async Task<IActionResult> ProductDetails()
        {
            var viewModel = new ProductDetailViewModel
            {
                SelectedProduct = await _productsService.GetProductById(
                                            Convert.ToInt32(Request.RouteValues["id"]))
            };

            return View("ProductDetails", viewModel);
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
