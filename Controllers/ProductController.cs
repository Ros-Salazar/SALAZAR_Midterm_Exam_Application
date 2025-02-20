using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace SALAZAR_Midterm_Exam_Application.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private static List<Product> products = new List<Product>
        {
            new Product { Id = 1, Name = "Smartphone", Description = "A high-tech smartphone", Price = 699.99, Theme = "Gadgets" },
            new Product { Id = 2, Name = "Laptop", Description = "A powerful laptop", Price = 1299.99, Theme = "Gadgets" },
            new Product { Id = 3, Name = "Smartwatch", Description = "A stylish smartwatch", Price = 199.99, Theme = "Gadgets" },
            new Product { Id = 4, Name = "Headphones", Description = "A noise-cancelling headphones", Price = 99.99, Theme = "Gadgets" },
        };

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetProducts()
        {
            return Ok(products);
        }

        [HttpGet("{id}")]
        public ActionResult<Product> GetProduct(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }

        [HttpGet("theme/{theme}")]
        public ActionResult<IEnumerable<Product>> GetProductsByTheme(string theme)
        {
            var filteredProducts = products.Where(p => p.Theme == theme).ToList();
            return Ok(filteredProducts);
        }

        [HttpPost]
        public ActionResult<Product> CreateProduct(Product product)
        {
            product.Id = products.Count + 1;
            products.Add(product);
            return CreatedAtAction(nameof(GetProduct), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateProduct(int id, Product updatedProduct)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Description = updatedProduct.Description;
            product.Price = updatedProduct.Price;
            product.Theme = updatedProduct.Theme;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var product = products.Find(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            products.Remove(product);
            return NoContent();
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public string Theme { get; set; }
    }
}