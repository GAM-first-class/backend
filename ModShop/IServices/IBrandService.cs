using ModShop.Entities;

namespace ModShop.IServices
{
    public interface IBrandService
    {
        Guid Create(string name, string description, bool isactive);

        void Update(Guid id, string name, string description , bool isactive);
        void Delete(Guid id);
        Brand? Get(Guid id);
        List<Brand> GetAll();
    }
}
