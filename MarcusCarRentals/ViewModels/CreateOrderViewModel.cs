namespace MarcusCarRentals.ViewModels
{
    public class CreateOrderViewModel
    {
        public int CarId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public CreateOrderViewModel(int carId)
        {
            CarId = carId;
        }
        public CreateOrderViewModel()
        {
            
        }
    }
}
