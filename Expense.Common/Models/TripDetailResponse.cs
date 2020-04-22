using System;
using System.Collections.Generic;
using System.Text;

namespace Expense.Common.Models
{
    public class TripDetailResponse
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public decimal Amount { get; set; }

        public DateTime Date { get; set; }

        public DateTime StartDateLocal => Date.ToLocalTime();

        public string PicturePath { get; set; }

        public TripResponse Trip { get; set; }

    }
}
