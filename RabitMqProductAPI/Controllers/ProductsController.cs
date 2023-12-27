using Microsoft.AspNetCore.Mvc;
using RabitMqProductAPI.Models;
using RabitMqProductAPI.RabbitMQ;
using RabitMqProductAPI.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RabitMqProductAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        private readonly IProductService productService;
        private readonly IRabitMQProduct rabitMQProduct;

        public ProductsController(IProductService _productService, IRabitMQProduct _rabitMQProducer)
        {
            productService = _productService;
            rabitMQProduct = _rabitMQProducer;
        }

        [HttpGet("productlist")]
        public IEnumerable<Product> Get()
        {
            return productService.GetProductList();
        }

        [HttpGet("getproductbyid")]
        public Product GetById(int id)
        {
            return productService.GetProductById(id);
        }

        [HttpPost("addproduct")]
        public Product Insert([FromBody] Product product)
        {
            var newProduct = productService.AddProduct(product);
            rabitMQProduct.SendProductMess(newProduct);
            Console.WriteLine($"Product message seed: {newProduct}");
            return newProduct;
        }

        [HttpPut("updateproduct")]
        public Product Update([FromBody] Product product)
        {
            return productService.UpdateProduct(product);
        }

        [HttpDelete("{id}")]
        public bool Delete(int id)
        {
            return productService.DeleteProduct(id);
        }
    }
}
