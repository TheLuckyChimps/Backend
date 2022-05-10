using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TPL.Data.Atributes;
using TPL.Data.Dtos.ProductDtos;
using TPL.Services.Interfaces;

namespace TPL.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [JwtAuthorizeAttribute]
        [HttpPost("Create")]
        public async Task<IActionResult> CreateProduct(ProductCreateDto productDto)
        {
            var response = await productService.CreateProduct(productDto);
            return Ok(response);
        }


        [HttpGet("Get-All")]
        public async Task<IActionResult> CreateStation()
        {
            var response = await productService.GetAllProducts();
            return Ok(response);
        }
    }
}
