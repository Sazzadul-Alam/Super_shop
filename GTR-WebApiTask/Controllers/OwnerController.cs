using GTR_WebApiTask.DB;
using GTR_WebApiTask.Model;
using GTR_WebApiTask.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace GTR_WebApiTask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OwnerController : ControllerBase
    {
        taskContext db;
        ProductRepo ProRepo;
        CategoryRepo CateRepo;

        public OwnerController(taskContext dbContext)
        {
            db = dbContext;
            ProRepo = new ProductRepo(db);
            CateRepo = new CategoryRepo(db);
        }

        // Get all products
        [HttpGet("product/All")]
        public List<Product> GetAllProducts()
        {
            return ProRepo.Get();
        }

        // Get all categories
        [HttpGet("category/All")]
        public List<Category> GetAllCategories()
        {
            return CateRepo.Get();
        }

        // Create a new product
        [HttpPost("product/Create")]
        [Authorize]
        public ActionResult CreateProduct(Product model)
        {
            if (ProRepo.Add(model))
            {
                return Ok("Product created successfully.");
            }
            else
            {
                return BadRequest("Failed to create the product.");
            }
        }

        // Create a new category
        [HttpPost("category/Create")]
        [Authorize]
        public ActionResult CreateCategory(Category model)
        {
            if (CateRepo.Add(model))
            {
                return Ok("Category created successfully.");
            }
            else
            {
                return BadRequest("Failed to create the category.");
            }
        }

        // Delete a product by ID
        [HttpDelete("product/Delete/{id}")]
        [Authorize]
        public ActionResult DeleteProduct(int id)
        {
            ProRepo.Delete(id);
            return Ok("Product deleted successfully.");
        }

        // Delete a category by ID
        [HttpDelete("category/Delete/{id}")]
        [Authorize]
        public ActionResult DeleteCategory(int id)
        {
            CateRepo.Delete(id);
            return Ok("Category deleted successfully.");
        }

        // Update a product
        [HttpPut("product/Update/{id}")]
        [Authorize]
        public ActionResult UpdateProduct(int id, Product model)
        {
            var existingProduct = ProRepo.Get(id);

            if (existingProduct == null)
            {
                return NotFound("Product not found.");
            }

            model.Id = id;
            ProRepo.Edit(model);
            return Ok("Product updated successfully.");
        }

        // Update a category
        [HttpPut("category/Update/{id}")]
        [Authorize]
        public ActionResult UpdateCategory(int id, Category model)
        {
            var existingCategory = CateRepo.Get(id);

            if (existingCategory == null)
            {
                return NotFound("Category not found.");
            }

            model.Id = id;
            CateRepo.Edit(model);
            return Ok("Category updated successfully.");
        }
    }
}
