using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Data.Data
{
    public class OrderItem
    {
        [Required]
        public int OrderItemId { get; set; }
        [Required]
        public int OrderId { get; set; }
        public Order Order { get; set; }

        [Required]
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int MenuItemCount { get; set; }
    }
}
