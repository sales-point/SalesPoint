using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class MenuSetInView
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public IEnumerable<MenuItemSetView> Items { get; set; }
    }
}
