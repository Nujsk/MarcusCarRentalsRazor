﻿using MarcusCarRentals.Models;

namespace MarcusCarRentals.ViewModels
{
    public class OrderViewModel
    {
        public int OrderId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string CarBrand { get; set; }
        public string CarModel { get; set; }
        public IEnumerable<Order>? ActiveOrders { get; set; }
        public IEnumerable<Order>? PastOrders { get; set; }
    }
}