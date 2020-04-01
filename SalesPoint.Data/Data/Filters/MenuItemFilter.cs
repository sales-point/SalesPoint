using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Data.Data.Filters
{
    public class MenuItemFilter
    {
        public string Name { get; set; }
        public int? MenuTypeId { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }
    }
}
