using MarcusCarRentals.Models;

namespace MarcusCarRentals.Data
{
    public class UserRepository : IUser
    {
        private readonly ApplicationDbContext applicationDbContext;
        public UserRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<User> GetAll()
        {
            return applicationDbContext.Users.OrderBy(x => x.Email);
        }
        public User GetById(int id)
        {
            return applicationDbContext.Users.FirstOrDefault(s => s.UserId == id);
        }
        public void Add(User user)
        {
            applicationDbContext.Users.Add(user);
            applicationDbContext.SaveChanges();
        }

        public void Update(User user)
        {
            applicationDbContext.Update(user);
            applicationDbContext.SaveChanges();
        }

        public void Delete(User user)
        {
            applicationDbContext.Remove(user);
            applicationDbContext.SaveChanges();
        }
    }
}
