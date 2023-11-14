using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tonyzeman.Models;
using Tonyzeman.Repository.IReposatory;
using System;
using System.IO;

namespace Tonyzeman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment)
        {
            this.unitOfWork = unitOfWork;
            _webHostEnvironment = webHostEnvironment;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var listOfProducts = unitOfWork.Product.GetAll();
            return Ok(listOfProducts);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = unitOfWork.Product.Get(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound(); // Return 404 Not Found when the product is not found
            }
        }

        [HttpGet("name")]
        public ActionResult GetByName(string name)
        {
            var product = unitOfWork.Product.GetByName(name);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return NotFound(); // Return 404 Not Found when the product is not found
            }
        }

        [HttpPost]
        public ActionResult Add( Product product)
        {
            if (product == null)
            {
                return BadRequest("Invalid data");
            }

            if (ModelState.IsValid)
            {
                //if (product.PhotoFile != null && product.PhotoFile.Length > 0)
                //{
                //    var uniqueFileName = Guid.NewGuid().ToString() + "_" + product.PhotoFile.FileName;
                //    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products", uniqueFileName);

                //    using (var stream = new FileStream(filePath, FileMode.Create))
                //    {
                //        product.PhotoFile.CopyTo(stream);
                //    }

                //    product.PhotoPath = "/images/products/" + uniqueFileName;
                //}

                unitOfWork.Product.Add(product);
                unitOfWork.Save();

                // Return the created product with a 201 Created status
                return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, Product product)
        {
            var existingProduct = unitOfWork.Product.Get(id);
            if (existingProduct == null)
            {
                return NotFound();
            }

            // Check if a new photo is provided and update the file if necessary
            //if (product.PhotoFile != null && product.PhotoFile.Length > 0)
            //{
            //    var uniqueFileName = Guid.NewGuid().ToString() + "_" + product.PhotoFile.FileName;
            //    var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images/products", uniqueFileName);

            //    using (var stream = new FileStream(filePath, FileMode.Create))
            //    {
            //        product.PhotoFile.CopyTo(stream);
            //    }

            //    existingProduct.PhotoPath = "/images/products/" + uniqueFileName;
            //}

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
            existingProduct.Description = product.Description;
            existingProduct.Stock = product.Stock;
            existingProduct.CategoryId = product.CategoryId;

            unitOfWork.Product.Update(existingProduct);
            unitOfWork.Save();

            return NoContent(); // Return 204 No Content after successful update
        }


        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var product = unitOfWork.Product.Get(id);
            if (product == null)
            {
                return NotFound();
            }

            unitOfWork.Product.Delete(id);
            unitOfWork.Save();
            return NoContent(); // Return 204 No Content after successful deletion
        }

        // Helper method to check if a string is a valid Base64 string
        private bool IsBase64String(string s)
        {
            try
            {
                Convert.FromBase64String(s);
                return true;
            }
            catch (FormatException)
            {
                return false;
            }
        }
    }
}
