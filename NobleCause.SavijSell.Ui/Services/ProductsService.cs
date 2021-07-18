using NobleCause.SavijSell.Ui.Models;
using NobleCause.SavijSell.Ui.Repositories;
using System.Collections.Generic;

namespace NobleCause.SavijSell.Ui.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public List<Product> GetProducts()
        {
            return _productsRepository.GetProducts();
        }
    }
}
