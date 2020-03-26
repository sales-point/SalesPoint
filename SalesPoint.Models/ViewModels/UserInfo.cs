using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class UserInfo
    {
        public Guid? UserId { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
    }
}
