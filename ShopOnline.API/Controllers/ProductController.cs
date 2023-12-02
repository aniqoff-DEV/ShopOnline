using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShopOnline.API.Extensions;
using ShopOnline.API.Repositories.Contracts;
using ShopOnline.Models.Dtos;

namespace ShopOnline.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetItems()
        {
            try
            {
                var products = await _productRepository.GetItems();
                var productCatagories = await _productRepository.GetCategories();

                if(products == null || productCatagories == null)
                {
                    return NotFound();
                }
                else
                {
                    var productDtos = products.ConvertToDto(productCatagories);

                    return Ok(productDtos);
                }
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError,
                    ex.Message);
            }
        }
    }
}
