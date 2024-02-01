using MarcusCarRentals.Models;

namespace MarcusCarRentals.Data
{
    public class CarRepository : ICar
    {
        private readonly ApplicationDbContext applicationDbContext;
        public CarRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Car> GetAll()
        {
            return applicationDbContext.Cars.OrderBy(x => x.Model);
        }
        public Car GetById(int id)
        {
            return applicationDbContext.Cars.FirstOrDefault(s => s.CarId == id);
        }
        public void Add(Car car)
        {
            applicationDbContext.Cars.Add(car);
            applicationDbContext.SaveChanges();
        }

        public void Update(Car car)
        {
            applicationDbContext.Update(car);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Car car)
        {
            applicationDbContext.Remove(car);
            applicationDbContext.SaveChanges();
        }
        public string GetImagePath(string brand)
        {
            string brandToLower = brand.ToLower();
            return $"/IMG/{brandToLower}.png";
        }
    }
}
