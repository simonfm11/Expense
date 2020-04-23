using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expense.Web.Data.Entities
{
    public class TripDetailsEntity
    {
        public int Id { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime Date { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd hh:mm}", ApplyFormatInEditMode = false)]
        public DateTime DateLocal => Date.ToLocalTime();

        [Display(Name = "Amount")]
        public decimal Amount { get; set; }

        [MaxLength(150, ErrorMessage = "The {0} field can not have more than {1} characters.")]
        public string Description { get; set; }

        [Display(Name = "Picture")]
        public string PicturePath { get; set; }

        public TripEntity Trip { get; set; }

        public ExpenseTypeEntity ExpenseType { get; set; }

    }
}