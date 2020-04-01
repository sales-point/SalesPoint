using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace SalesPoint.Data.Data
{
    public class MenuSet
    {
        [Required]
        public int MenuSetId { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<MenuItemMenuSet> SetItems {get;set;}

        [Required]
        public string Description { get; set; }
    }
}
