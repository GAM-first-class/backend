using Microsoft.AspNetCore.Mvc;
using ModShop.IServices;

namespace ModShop.Controllers
{
    [ApiController]
    [Route("Product")]
    internal sealed class ProductController : ControllerBase
    {
        private readonly IProductService ProductService;

        public ProductController(IProductService ProductService)
        {
            this.ProductService = ProductService;
        }

        [HttpPost]
        [Route("Create")]
        public IActionResult Create(string name, string description, int price, int discountprice
            , Guid categoryid, Guid brandid, bool isactive)
        {
            var key = ProductService.Create(name, description, price, discountprice, categoryid, brandid, isactive);
            return Ok(key);
        }
        [HttpPut]
        [Route("Update")]
        public IActionResult Update(Guid Id ,string name, string description, int price, int discountprice
            , Guid categoryid, Guid brandid, bool isactive)
        {
            ProductService.Update(Id,name, description, price, discountprice, categoryid, brandid, isactive);
            return Ok(true);
        }
        [HttpDelete]
        [Route("Delete")]
        public IActionResult Delete(Guid Id)
        {
            ProductService.Delete(Id);
            return Ok(true);
        }
        [HttpGet]
        [Route("Get")]
        public IActionResult Get(Guid Id)
        {
            var read = ProductService.Get(Id);
            return Ok(read);
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GETAll()
        {
            var readall = ProductService.GetAll();
            return Ok(readall);
        }
    }
}
