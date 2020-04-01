using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class OrderItemInView
    {
        [Required]
        public int? ItemId { get; set; }
        [Required]
        public int? Count { get; set; }
    }
}
