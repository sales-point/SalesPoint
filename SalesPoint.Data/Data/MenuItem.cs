using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Data.Data
{
    public class MenuItem
    {
        [Required]
        public int MenuItemId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public decimal Weight { get; set; }

        [Required]
        public string Mixture { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public MenuType MenuType { get; set; }

        [Required]
        public int MenuTypeId { get; set; }

        public IEnumerable<MenuItemMenuSet> ItemSets { get; set; }

        public int? MenuSetId { get; set; }
        public MenuSet MenuSet { get; set; }

    }
}
