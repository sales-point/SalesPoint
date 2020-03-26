using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Data.Data
{
    public class MenuItemMenuSet
    {
        public int MenuItemId { get; set; }
        public MenuItem MenuItem { get; set; }
        public int MenuItemCount { get; set; }
        public int MenuSetId { get; set; }

        public MenuSet MenuSet { get; set; }
    }
}
