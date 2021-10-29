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
                         .WithOAuthBearerToken("eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJzdWIiOiIxIiwianRpIjoiOWQzYWU0YWQtNjI4ZS00OWIyLWFiMDAtMGUyY2I0NmNkMjkyIiwiaHR0cDovL3NjaGVtYXMueG1sc29hcC5vcmcvd3MvMjAwNS8wNS9pZGVudGl0eS9jbGFpbXMvbmFtZSI6IlNhdmlqQ29kZXIiLCJodHRwOi8vc2NoZW1hcy54bWxzb2FwLm9yZy93cy8yMDA1LzA1L2lkZW50aXR5L2NsYWltcy9lbWFpbGFkZHJlc3MiOiJzYXZpai5jb2RlckBzaGFya2xhc2Vycy5jb20iLCJleHAiOjE2MzQ2OTcwODQsImlzcyI6ImxvY2FsaG9zdDo0NDMyOCIsImF1ZCI6ImxvY2FsaG9zdDo0NDMyOCJ9.l-AENf9_gQi1bDwTT9sCfRica5TNvADj8bv9512z8Bo")
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
