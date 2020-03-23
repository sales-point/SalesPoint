using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Data.Data
{
    public class MenuType
    {
        [Required]
        public int MenuTypeId { get; set; }

        [Required]
        public string Name { get; set; }
    }
}
