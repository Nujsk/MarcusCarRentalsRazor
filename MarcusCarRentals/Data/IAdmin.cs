using MarcusCarRentals.Models;

namespace MarcusCarRentals.Data
{
    public interface IAdmin
    {
        //Car related actions
        Car GetCarId(int id);
        IEnumerable<Car> GetAllCars();
        void Add(Car car);
        void Update(Car car);
        void Delete(Car car);

        //User related actions
        User GetUserId(int id);
        IEnumerable<User> GetAllUsers();
        void Add(User user);
        void Update(User user);
        void Delete(User user);

        //Order related actions
        Order GetOrderById(int id);
        IEnumerable<Order> GetAllOrders();
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
    }
}
