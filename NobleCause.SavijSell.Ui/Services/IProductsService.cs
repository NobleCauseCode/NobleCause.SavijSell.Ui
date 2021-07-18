using NobleCause.SavijSell.Ui.Models;
using System.Collections.Generic;

namespace NobleCause.SavijSell.Ui.Services
{
    public interface IProductsService
    {
        List<Product> GetProducts();
    }
}
