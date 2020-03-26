using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Data
{
    public class ApplicationUser : IdentityUser<Guid>
    {
        [Required]
        public string FullName { get; set; }
    }
}
