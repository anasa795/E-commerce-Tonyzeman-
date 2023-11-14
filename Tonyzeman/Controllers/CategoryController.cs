using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Tonyzeman.Models;
using Tonyzeman.Repository.IReposatory;

namespace Tonyzeman.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IUnitOfWork unitOfWork;

        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var listOfProducts = unitOfWork.Category.GetAll();

            return Ok(listOfProducts);
        }

        [HttpGet("{id}")]
        public ActionResult Get(int id)
        {
            var product = unitOfWork.Category.Get(id);
            if (product != null)
            {
                return Ok(product);
            }
            else
            {
                return BadRequest();
            }
        }
        //[HttpGet("name")]
        //public ActionResult GetName(string name)
        //{
        //    var product = unitOfWork.Product.GetByName(name);
        //    return Ok(product);
        //}

        [HttpPost]
        public ActionResult Add(Category category)
        {
            if (category == null) return BadRequest();
            if (ModelState.IsValid)
            {
                unitOfWork.Category.Add(category);
                try
                {
                    unitOfWork.Save();
                    return Created("done", unitOfWork.Category.Get(category.ID));
                }
                catch
                {
                    return BadRequest();
                }

            }
            else
            {
                return BadRequest(ModelState);
            }
        }



        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            unitOfWork.Category.Delete(id);
            unitOfWork.Save();
            return Created("done", id);
            //return NoContent();
        }


        [HttpPut("{id}")]
        public ActionResult Update(int id, Category category)
        {
            var existinCategory = unitOfWork.Category.Get(id);
            if (existinCategory == null)
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

            existinCategory.Name = category.Name;
            unitOfWork.Category.Update(existinCategory);
            unitOfWork.Save();

            return NoContent(); // Return 204 No Content after successful update
        }
    }
}
