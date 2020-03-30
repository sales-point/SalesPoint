using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class MenuItemInView
    {
        [Required]
        public int? MenuTypeId { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public decimal? Price { get; set; }

        [Required]
        public string Mixture { get; set; }

        [Required]
        public decimal? Weight { get; set; }

        public int? MenuSetId { get; set; }
    }
}
