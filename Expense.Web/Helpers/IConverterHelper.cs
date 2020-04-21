using Expense.Common.Models;
using Expense.Web.Data.Entities;
using System.Collections.Generic;

namespace Expense.Web.Helpers
{
    public interface IConverterHelper
    {
        List<TripResponse> ToTripResponse(List<TripEntity> tripEntity);
    }
}
