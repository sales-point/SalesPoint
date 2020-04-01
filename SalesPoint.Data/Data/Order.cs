using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Data.Data
{
    public class Order
    {
        [Required]
        public int OrderId { get; set; }
        public IEnumerable<OrderItem> OrderItems { get; set; }
        public string Comment { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        [Required]
        public int StepId { get; set; }
        public Step Step { get; set; }
        public bool Paid { get; set; } = false;
        public Guid? CustomerUserId { get; set; }
        public ApplicationUser CustomerUser { get; set; }
        public Guid? ManagerUserId { get; set; }
        public ApplicationUser ManagerUser { get; set; }
        [Required]
        public DateTime? OrderDate { get; set; } = DateTime.Now;
    }
}
