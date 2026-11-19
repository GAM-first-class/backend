using ModShop.Data;
using ModShop.Entities;
using ModShop.IServices;

namespace ModShop.Services
{
    internal sealed class ProductService : IProductService
    {
        public readonly ModShopDbContext DBContext;

        public ProductService(ModShopDbContext DBContext)
        {
            this.DBContext = DBContext;
        }

        public Guid Create(string name, string description, int price, int discountprice, Guid categoryid, Guid brandid, bool isactive)
        {
            var product = Product.Create(name, description, price, discountprice, categoryid, brandid, isactive);
            DBContext.Products.Add(product);
            DBContext.SaveChanges();
            return product.Id;
        }

        public void Delete(Guid id)
        {
            var product = DBContext.Products.Where(p => p.Id == id).FirstOrDefault();
            DBContext.Products.Remove(product);
            DBContext.SaveChanges();
        }

        public Product? Get(Guid id)
        {
            var read = DBContext.Products.Where(r => r.Id == id).FirstOrDefault();
            return read;
        }

        public List<Product> GetAll()
        {
            var readall = DBContext.Products.ToList();
            return readall;
        }

        public void Update(Guid id, string name, string description, int price, int discountprice, Guid categoryid, Guid brandid, bool isactive)
        {
            var product = DBContext.Products.Where(p => p.Id == id).FirstOrDefault();
            product.Update(name,description,price,discountprice,categoryid,brandid,isactive);
            DBContext.Products.Update(product);
            DBContext.SaveChanges();
        }
    }
}
