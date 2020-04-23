using System.Collections.Generic;

namespace Expense.Web.Data.Entities
{
    public class CountryEntity
    {
        public int Id { get; set; }

        public string Country { get; set; }

        public ICollection<CityEntity> Cities { get; set; }
    }
}