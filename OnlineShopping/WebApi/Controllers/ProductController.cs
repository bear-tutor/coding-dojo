using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController
    {
        public static List<ProductInfo> Products { get; private set; }

        static ProductController()
        {
            Products = new List<ProductInfo>
            {
                new ProductInfo{ Id = "1", Name = "Apple iPhone X", Price = 999.00 },
                new ProductInfo{ Id = "2", Name = "Huawei Mat 20 Pro", Price = 936.17 },
                new ProductInfo{ Id = "3", Name = "Honor View 20", Price = 769 },
                new ProductInfo{ Id = "4", Name = "Google Pixel 3 XL", Price = 889.99 },
                new ProductInfo{ Id = "5", Name = "Oneplus 6T", Price = 541.67 },
                new ProductInfo{ Id = "6", Name = "Sony Xperia XZ3", Price = 189.99 },
                new ProductInfo{ Id = "7", Name = "Samsung Galaxy S9", Price = 494.99 },
            };
        }

        // TODO: Get all products
        // TODO: Add new product
        // TODO: Remove a product by Id
        // TODO: Update a product
    }
}