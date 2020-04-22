using Expense.Common.Models;
using Expense.Web.Data.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Expense.Web.Helpers
{
    public class ConverterHelper : IConverterHelper
    {
        public List<TripResponse> ToTripResponse(List<TripEntity> tripEntity)
        {
            return tripEntity.Select(t => new TripResponse
            {
                Id = t.Id,
                City = t.City.City,
                Description = t.Description,
                StartDate = t.StartDateLocal,
                EndDate = t.EndDateLocal,
                TotalAmount = t.TotalAmount,
                TripDetails = t.TripDetails?.Select(td => new TripDetailResponse
                {
                    Amount = td.Amount,
                    Date = td.Date,
                    Description = td.Description,
                    PicturePath = td.PicturePath
                }).ToList(),
                User = ToUserResponse(t.User)
            }).ToList();
        }

        private UserResponse ToUserResponse(UserEntity user)
        {
            if (user == null)
            {
                return null;
            }

            return new UserResponse
            {
                Address = user.Address,
                Document = user.Document,
                Email = user.Email,
                FirstName = user.FirstName,
                Id = user.Id,
                LastName = user.LastName,
                PhoneNumber = user.PhoneNumber,
                PicturePath = user.PicturePath,
                UserType = user.UserType
            };
        }

    }
}
