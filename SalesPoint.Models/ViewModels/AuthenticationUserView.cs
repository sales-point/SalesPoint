using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class AuthenticationUserView : UserView
    {
        public bool RememberMe { get; set; }
    }
}
