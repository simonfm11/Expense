using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense.Web.Data.Entities
{
    public class CountryEntity
    {
        public int id { get; set; }

        public string Country { get; set; }

        public ICollection<CityEntity> cities { get; set; }
    }
}
