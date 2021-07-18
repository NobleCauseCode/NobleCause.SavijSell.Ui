using NobleCause.SavijSell.Ui.Models;
using System.Collections.Generic;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public interface IProductsRepository
    {
        List<Product> GetProducts();
    }
}
