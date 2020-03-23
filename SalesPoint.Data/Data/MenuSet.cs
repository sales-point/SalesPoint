using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Data.Data
{
    public class MenuSet
    {
        [Required]
        public int MenuSetId { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public virtual IEnumerable<MenuItem> MenuItems {get;set;}

        [Required]
        public string Description { get; set; }
    }
}
