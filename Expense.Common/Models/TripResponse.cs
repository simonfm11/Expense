using System;
using System.Collections.Generic;
using System.Text;

namespace Expense.Common.Models
{
    public class TripResponse
    {
        public int Id { get; set; }

        public string City { get; set; }

        public string  Description { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime StartDateLocal => StartDate.ToLocalTime();

        public DateTime? EndDate { get; set; }

        public DateTime? EndDateLocal => EndDate?.ToLocalTime();

        public decimal TotalAmount { get; set; }

        public UserResponse User { get; set; }

        public ICollection<TripDetailResponse> TripDetails { get; set; }
    }
}
