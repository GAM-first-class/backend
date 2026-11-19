using ModShop.Entities;

namespace ModShop.IServices;

public interface IUserService
{
    Guid Create(string userName, string phoneNumber, string password);
    void CompleteRegistration(Guid id, string firstName, string lastName, string email);
    void Update(Guid id, string userName, string firstName, string lastName, string email, string phoneNumber, string password);
    User? Get(Guid id);
    List<User> GetAll();
    void Delete(Guid id);
}
