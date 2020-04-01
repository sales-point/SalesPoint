using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class OrderItemOutView
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Description { get; set; }
        public string Mixture { get; set; }
        public int MenuTypeId { get; set; }
        public int MenuItemId { get; set; }
        public decimal Weight { get; set; }
        public int? MenuSetId { get; set; }
        public int Count { get; set; }
    }
}
