using MarcusCarRentals.Models;
using MarcusCarRentals.ViewModels;

namespace MarcusCarRentals.Data
{
    public interface IOrder
    {
        Order GetById(int id);
        IEnumerable<Order> GetAll();
        void Add(Order order);
        void Update(Order order);
        void Delete(Order order);
        IEnumerable<OrderViewModel> DisplayOrders(string user);
        IEnumerable<Order> GetActiveOrders(string userEmail);
        IEnumerable<Order> GetPastOrders(string userEmail);
    }
}
