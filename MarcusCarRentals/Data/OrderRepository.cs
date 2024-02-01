using MarcusCarRentals.Models;
using MarcusCarRentals.ViewModels;
using Microsoft.EntityFrameworkCore;

namespace MarcusCarRentals.Data
{
    public class OrderRepository : IOrder
    {
        private readonly ApplicationDbContext applicationDbContext;
        public OrderRepository(ApplicationDbContext applicationDbContext)
        {
            this.applicationDbContext = applicationDbContext;
        }
        public IEnumerable<Order> GetAll()
        {
            return applicationDbContext.Orders.Include(x => x.User).Include(s=>s.Car).ToList();
        }
        public Order GetById(int id)
        {
            return applicationDbContext.Orders.Include(x => x.User).Include(s => s.Car)
                .FirstOrDefault(s => s.OrderId == id);
        }
        public void Add(Order order)
        {
            applicationDbContext.Orders.Add(order);
            applicationDbContext.SaveChanges();
        }

        public void Update(Order order)
        {
            applicationDbContext.Update(order);
            applicationDbContext.SaveChanges();
        }

        public void Delete(Order order)
        {
            applicationDbContext.Remove(order);
            applicationDbContext.SaveChanges();
        }
        public IEnumerable<OrderViewModel>DisplayOrders(string userEmail)
        {
            var orders = applicationDbContext.Orders
                .Include(o => o.Car)
                .Where(o => o.User.Email == userEmail)
                .ToList();

            var orderViewModels = orders.Select(o => new OrderViewModel
            {
                OrderId = o.OrderId,
                StartDate = o.StartDate,
                EndDate = o.EndDate,
                CarBrand = o.Car.Brand,
                CarModel = o.Car.Model
            });

            return orderViewModels;
        }
        public IEnumerable<Order>GetActiveOrders(string userEmail)
        {
            var activeOrders = applicationDbContext.Orders
                .Include(o => o.Car)
                .Include(c=>c.User)
                .Where(o => o.User.Email == userEmail && o.IsActive)
                .ToList();
            return activeOrders;
        }
        public IEnumerable<Order> GetPastOrders(string userEmail)
        {
            var inactiveOrders = applicationDbContext.Orders
                .Include(o => o.Car)
                .Where(o => o.User.Email == userEmail && !o.IsActive)
                .ToList();
            return inactiveOrders;
        }
    }
}