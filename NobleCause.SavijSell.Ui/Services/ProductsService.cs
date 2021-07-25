using NobleCause.SavijSell.Ui.Models;
using NobleCause.SavijSell.Ui.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductsRepository _productsRepository;

        public ProductsService(IProductsRepository productsRepository)
        {
            _productsRepository = productsRepository;
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _productsRepository.GetProducts();
        }
    }
}
