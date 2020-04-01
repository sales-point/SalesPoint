using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class OrderInView
    {
        public IEnumerable<OrderItemInView> Items { get; set; }
        public string Comment { get; set; }
        [Required]
        public string Address { get; set; }

        public string PhoneNumber { get; set; }
    }
}
