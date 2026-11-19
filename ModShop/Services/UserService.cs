using ModShop.Data;
using ModShop.Entities;
using ModShop.IServices;

namespace ModShop.Services
{
    public class UserService(ModShopDbContext context) : IUserService
    {
        public void CompleteRegistration(Guid id, string firstName, string lastName, string email)
        {
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            user?.CompleteRegistration(firstName, lastName, email);
            context.SaveChanges();
        }

        public Guid Create(string userName, string phoneNumber, string password)
        {
            var user = User.Create(userName, null, null, null, phoneNumber, password);
            context.Users.Add(user);
            context.SaveChanges();
            return user.Id;
        }

        public void Delete(Guid id)
        {
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            
            if (user != null)
            {
                context.Users.Remove(user);
                context.SaveChanges();
            }
        }

        public User? Get(Guid id)
        {
            return context.Users.Where(u => u.Id == id).FirstOrDefault();
        }

        public List<User> GetAll()
        {
            return context.Users.ToList();
        }

        public void Update(Guid id, string userName, string firstName, string lastName, string email, string phoneNumber, string password)
        {
            var user = context.Users.Where(u => u.Id == id).FirstOrDefault();
            if (user != null)
            {
                user.Update(userName, firstName, lastName, email, phoneNumber, password);
                context.SaveChanges();
            }
        }
    }
}
