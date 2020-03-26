﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class MenuSetOutView
    {
        public int MenuSetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public IEnumerable<MenuItemSetOutView> Items { get; set; }
    }
}