using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class RoleInView
    {
        public RoleInfo Role { get; set; }
        public PagedView PageModel { get; set; }
    }
}
