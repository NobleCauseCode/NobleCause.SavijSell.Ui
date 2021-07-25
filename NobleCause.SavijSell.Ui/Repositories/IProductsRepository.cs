using NobleCause.SavijSell.Ui.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public interface IProductsRepository
    {
        Task<List<Product>> GetProducts();
    }
}
