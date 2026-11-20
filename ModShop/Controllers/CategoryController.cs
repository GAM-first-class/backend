using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Update.Internal;
using Microsoft.Identity.Client;
using ModShop.IServices;
using ModShop.Services;
using System.Runtime.InteropServices;

namespace ModShop.Controllers
{
    [ApiController]
    [Route("Category")]
    internal sealed class CategoryController : ControllerBase
    {
        private readonly ICategoryService categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string name, string description, Guid? parentcategoryid, bool isactive)
        {
            var category = categoryService.Create(name, description, parentcategoryid,isactive);
            return Ok(category);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Guid id,string name, string description, Guid? parentcategoryid, bool isactive)
        {
            categoryService.Update(id, name, description, parentcategoryid, isactive);
            return Ok(true);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid id)
        {
            categoryService.Delete(id);
            return Ok(true);
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get(Guid id)
        {
            var read = categoryService.Get(id);
            return Ok(read);
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            var readall = categoryService.GetAll();
            return Ok(readall);
        }
    }
}
