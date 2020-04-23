using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Expense.Web.Data.Entities
{
    public class CityEntity
    {

        public int Id { get; set; }

        public string City { get; set; }

        public CountryEntity Country { get; set; }

        public ICollection<TripEntity> Trips { get; set; }
    }
}