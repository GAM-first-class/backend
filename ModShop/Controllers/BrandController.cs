using Microsoft.AspNetCore.Mvc;
using ModShop.Entities;
using ModShop.IServices;
using ModShop.Services;

namespace ModShop.Controllers
{
    [ApiController]
    [Route("Brand")]
    internal sealed class BrandController : ControllerBase
    {
        private readonly IBrandService brandService;

        public BrandController(IBrandService brandService)
        {
            this.brandService = brandService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string name, string description, bool isactive)
        {
            var key = brandService.Create(name, description,isactive);
            return Ok(key);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Guid Id, string name, string description, bool isactive)
        {
            brandService.Update(Id, name, description, isactive);
            return Ok(true);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid Id)
        {
            brandService.Delete(Id);
            return Ok(true);
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get(Guid Id)
        {
            var read = brandService.Get(Id);
            return Ok(read);
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GETAll()
        {
            var readall = brandService.GetAll();
            return Ok(readall);
        }
    }
}
