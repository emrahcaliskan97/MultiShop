using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductDetailDtos;
using MultiShop.Catalog.Services.ProductDetailServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailsController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailsController(IProductDetailService productService)
        {
            _productDetailService = productService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductDetailsList()
        {
            var values = await _productDetailService.GetAllProductDetailAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductDetailsById(string id)
        {
            var values = await _productDetailService.GetByIdProductDetailAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductDetails(CreateProductDetailDto createProductDetailsDto)
        {
            await _productDetailService.CreateProductDetailAsync(createProductDetailsDto);
            return Ok("Ürün detayı başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductDetails(string id)
        {
            await _productDetailService.DeleteProductDetailAsync(id);
            return Ok("Ürün detayı başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductDetails(UpdateProductDetailDto updateProductDetailsDto)
        {
            await _productDetailService.UpdateProductDetailAsync(updateProductDetailsDto);
            return Ok("Ürün detayı başarıyla güncellendi");
        }
    }
}
