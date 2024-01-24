using System.ComponentModel.DataAnnotations.Schema;

namespace MarcusCarRentals.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Car Car { get; set; }
        public User User { get; set; }
        public bool IsActive { get; set; }

        public Order()
        {

        }
    }
}
