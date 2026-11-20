using Microsoft.EntityFrameworkCore;
using ModShop.Data;
using ModShop.Entities;
using ModShop.IServices;

namespace ModShop.Services
{
    internal sealed class BrandService : IBrandService
    {
        public readonly ModShopDbContext DBContext;

        public BrandService(ModShopDbContext DBContext)
        {
            this.DBContext = DBContext;
        }

        public Guid Create(string name, string description, bool isactive)
        {
            var brand =Brand.Create(name, description,isactive);
            DBContext.Brands.Add(brand);
            DBContext.SaveChanges();
            return brand.Id;
        }

        public void Delete(Guid id)
        {
            var brand = DBContext.Brands.Where(b => b.Id == id).FirstOrDefault();
            DBContext.Brands.Remove(brand);
            DBContext.SaveChanges();
        }

        public Brand? Get(Guid id)
        {
            var read = DBContext.Brands.Where(r => r.Id == id).FirstOrDefault();
            return read;
        }

        public List<Brand> GetAll()
        {
            var readall = DBContext.Brands.ToList();
            return readall;
        }

        public void Update(Guid id, string name, string description, bool isactive)
        {
            var brand = DBContext.Brands.Where(p => p.Id == id).FirstOrDefault();
            brand.Update(name, description, isactive);
            DBContext.Brands.Update(brand);
            DBContext.SaveChanges();
        }

   
    }
}
