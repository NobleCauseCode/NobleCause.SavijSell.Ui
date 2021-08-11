using Flurl;
using Flurl.Http;
using NobleCause.SavijSell.Ui.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public async Task<List<Product>> GetProducts()
        {

            return await "https://localhost:44328"
                         .AppendPathSegment("/api/Products")
                         .GetJsonAsync<List<Product>>();

            //var httpClient = new HttpClient();
            //var products = await httpClient.GetFromJsonAsync<List<Product>>("https://localhost:44328/api/Products");
            //return products;
        }

        public async Task<Product> GetProductsById(int id)
        {
            return await "https://localhost:44328"
                        .AppendPathSegment($"/api/Products/{id}")
                        .GetJsonAsync<Product>();
        }
    }
}
