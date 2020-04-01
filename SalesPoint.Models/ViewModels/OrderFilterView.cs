using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SalesPoint.Models.ViewModels
{
    public class OrderFilterView
    {
        public Guid? ManagerId { get; set; }
        public Guid? CustomerId { get; set; }
        public IEnumerable<int> StepIds { get; set; }
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
        [Required]
        public int Page { get; set; }
        [Required]
        public int CountPerPage { get; set; }
    }
}
