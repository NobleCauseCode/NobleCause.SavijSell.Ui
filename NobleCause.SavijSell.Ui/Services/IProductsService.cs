using NobleCause.SavijSell.Ui.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Services
{
    public interface IProductsService
    {
        Task<List<Product>> GetProducts();
        Task<Product> GetProductById(int id);
    }
}
