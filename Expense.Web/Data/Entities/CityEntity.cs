using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense.Web.Data.Entities
{
    public class CityEntity
    {
        public int Id { get; set; }

        public string City { get; set; }

        public CountryEntity Country { get; set; }

        public ICollection<TripEntity> trips { get; set; }
    }
}
