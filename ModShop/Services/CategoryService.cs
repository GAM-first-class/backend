using Microsoft.AspNetCore.Mvc;
using ModShop.Data;
using ModShop.Entities;
using ModShop.IServices;

namespace ModShop.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ModShopDbContext DBContext;
        public CategoryService(ModShopDbContext DBContext)
        {
            this.DBContext = DBContext;
        }

        public Guid Create(string name, string description, Guid? parentcategoryid, bool isactive)
        {
            var category = Category.Create(name, description, parentcategoryid, isactive);
            DBContext.Categories.Add(category);
            DBContext.SaveChanges();
            return category.Id;
        }

        public void Delete(Guid Id)
        {
            var category = DBContext.Categories.Where(c => c.Id == Id).FirstOrDefault();
            DBContext.Categories.Remove(category);
            DBContext.SaveChanges();
        }

        public Category? Get(Guid Id)
        {
            var read = DBContext.Categories.Where(r => r.Id == Id).FirstOrDefault();
            return read;
        }

        public List<Category> GetAll()
        {
            var readall = DBContext.Categories.ToList();
            return readall;
        }

        public void Update(Guid Id, string name, string description, Guid? parentcategoryid, bool isactive)
        {
            var category = DBContext.Categories.Where(c => c.Id == Id).FirstOrDefault();
            category.Update(name,description, parentcategoryid,isactive);
            DBContext.Categories.Update(category);
            DBContext.SaveChanges();
        }
    }
}
