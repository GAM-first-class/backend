using ModShop.Entities;

namespace ModShop.IServices
{
    public interface ICategoryService
    {
        Guid Create(string name, string description, Guid? parentcategoryid, bool isactive);
        void Update(Guid Id,string name, string description, Guid? parentcategoryid, bool isactive);
        void Delete(Guid Id);
        Category? Get (Guid Id);
        List<Category> GetAll();
    }
}
