using ModShop.Entities;

namespace ModShop.IServices
{
    public interface IProductService
    {
        Guid Create(string name, string description, int price, int discountprice
            , Guid categoryid, Guid brandid, bool isactive);

        void Update (Guid id , string name, string description, int price, int discountprice
            , Guid categoryid, Guid brandid, bool isactive);
        void Delete (Guid id);
        Product? Get(Guid id);
        List<Product> GetAll();

    }
}
