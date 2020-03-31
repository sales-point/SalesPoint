using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class OrderOutView
    {
        public int OrderId { get; set; }
        public string ManagerName { get; set; }
        public IEnumerable<OrderItemOutView> OrderItems { get; set; }
        public int StepId { get; set; }
        public decimal Price { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Comment { get; set; }
    }
}
