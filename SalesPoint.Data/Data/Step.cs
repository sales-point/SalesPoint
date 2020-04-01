using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Data.Data
{
    public class Step
    {
        public int StepId { get; set; }
        [Required]
        public string Name { get; set; }
    }
}
