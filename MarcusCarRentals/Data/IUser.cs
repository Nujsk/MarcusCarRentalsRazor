using MarcusCarRentals.Models;

namespace MarcusCarRentals.Data
{
    public interface IUser
    {
        User GetById(int id);
        IEnumerable<User> GetAll();
        void Add(User user);
        void Update(User user);
        void Delete(User user);
    }
}
