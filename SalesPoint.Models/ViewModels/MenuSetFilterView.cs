﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class MenuSetFilterView
    {
        public string Name { get; set; }
        public decimal? MinPrice { get; set; }
        public decimal? MaxPrice { get; set; }

        [Required]
        public int Page { get; set; }

        [Required]
        public int CountPerPage { get; set; }
    }
}
