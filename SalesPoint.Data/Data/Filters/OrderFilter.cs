using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Data.Data.Filters
{
    public class OrderFilter
    {
        public Guid? ManagerId { get; set; }
        public Guid? CustomerId { get; set; }
        public IEnumerable<int> StepIds { get; set; } = new List<int>();
        public DateTime? startDate { get; set; }
        public DateTime? endDate { get; set; }
    }
}
