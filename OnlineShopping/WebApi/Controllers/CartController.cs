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
    public class CartController
    {
        public static CartInfo Cart { get; private set; }

        static CartController()
        {
            Cart = new CartInfo();
        }

        // TODO: Get cart info
        // TODO: Add a product to the cart
        // TODO: Remove a product from the cart by product Id
    }
}