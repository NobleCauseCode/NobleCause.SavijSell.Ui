using Flurl;
using Flurl.Http;
using Flurl.Http.Configuration;
using Microsoft.AspNetCore.Http;
using NobleCause.SavijSell.Ui.Models;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public class ProductsRepository : RepositoryBase, IProductsRepository
    {
        

        public ProductsRepository(
                                  IFlurlClientFactory flurlClientFactory,
                                  IHttpContextAccessor httpContextAccessor):
                                base(flurlClientFactory, httpContextAccessor)
        {
            
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _flurlClient.Request("/api/Products")
                            .GetJsonAsync<List<Product>>();
        }

        public async Task<Product> GetProductsById(int id)
        {
            return await "https://localhost:44328"
                        .AppendPathSegment($"/api/Products/{id}")
                        .GetJsonAsync<Product>();
        }
    }
}
