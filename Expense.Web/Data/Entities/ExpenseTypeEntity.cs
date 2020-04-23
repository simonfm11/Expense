using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expense.Web.Data.Entities
{
    public class ExpenseTypeEntity
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The field {0} is mandatory.")]
        public string Expense { get; set; }

        public ICollection<TripDetailsEntity> TripDetails { get; set; }
    }
}