using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class UserInfoInView
    {
        [Required]
        public UserInfo User { get; set; }
        public PagedView PageModel { get; set; }
    }
}
