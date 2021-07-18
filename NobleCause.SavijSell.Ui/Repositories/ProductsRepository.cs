using NobleCause.SavijSell.Ui.Models;
using System;
using System.Collections.Generic;

namespace NobleCause.SavijSell.Ui.Repositories
{
    public class ProductsRepository : IProductsRepository
    {
        public List<Product> GetProducts()
        {
            // Call Api
            var products = new List<Product>();

            products.Add(new Product
            {
                Id = 1,
                Title = "Black Bag",
                Description = "A black bag - nice!",
                Image = $"/assets/images/1.jpg",
                Location = "Someplace, NC",
                Price = 50m
            });
            products.Add(new Product
            {
                Id = 2,
                Title = "Blue Shirt",
                Description = "A blue t-shirt",
                Image = $"/assets/images/2.jpg",
                Location = "SomeplaceElse, NC",
                Price = 15m
            });
            return products;
        }
    }
}
