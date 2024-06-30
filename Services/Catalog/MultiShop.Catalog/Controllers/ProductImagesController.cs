using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ProductImageDtos;
using MultiShop.Catalog.Services.ProductImageServices;

namespace MultiShop.Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductImagesController : ControllerBase
    {
        private readonly IProductImageService productImageService;

        public ProductImagesController(IProductImageService categoryService)
        {
            productImageService = categoryService;
        }

        [HttpGet]
        public async Task<IActionResult> ProductImageList()
        {
            var values = await productImageService.GetAllProductImageAsync();
            return Ok(values);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProductImageById(string id)
        {
            var values = await productImageService.GetByIdProductImageAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateProductImage(CreateProductImageDto createProductImageDto)
        {
            await productImageService.CreateProductImageAsync(createProductImageDto);
            return Ok("Ürün resmi başarıyla eklendi");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteProductImage(string id)
        {
            await productImageService.DeleteProductImageAsync(id);
            return Ok("Ürün resmi başarıyla silindi");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateProductImage(UpdateProductImageDto updateProductImageDto)
        {
            await productImageService.UpdateProductImageAsync(updateProductImageDto);
            return Ok("Ürün resmi başarıyla güncellendi");
        }
    }
}
