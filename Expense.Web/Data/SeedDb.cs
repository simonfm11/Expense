
using Expense.Common.Enums;
using Expense.Web.Data.Entities;
using Expense.Web.Helpers;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
 
namespace Expense.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;
        private readonly IUserHelper _userHelper;

        public SeedDb(
            DataContext dataContext,
            IUserHelper userHelper)
        {
            _dataContext = dataContext;
            _userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckExpenseTypeAsync();
            await CheckUserAsync("1111", "Simon", "Florez", "simonfm11@hotmail.com", "320 154 84 69", "Cra 11 # 54 -85", UserType.Admin);
            UserEntity user1 = await CheckUserAsync("2222", "Daniel", "lopez", "daniel@yopmail.com", "323 548 98 78", "La tierra del olvido", UserType.User);
            UserEntity user2 = await CheckUserAsync("3333", "Valentina", "trujillo", "valentina@yopmail.com", "312 768 32 45", "La playa con carabobo", UserType.User);
            await CheckTripsAsync(user1, user2);
        }

        private async Task CheckExpenseTypeAsync()
        {
            if (!_dataContext.ExpenseTypes.Any())
            {
                AddExpenseType("Food");
                AddExpenseType("Transport");
                AddExpenseType("stay");
                AddExpenseType("Representation");
                AddExpenseType("Other");
            }
            await _dataContext.SaveChangesAsync();
        }

        public async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.User.ToString());
        }

        private async Task<UserEntity> CheckUserAsync(
           string document,
           string firstName,
           string lastName,
           string email,
           string phone,
           string address,
           UserType userType)
        {
            UserEntity user = await _userHelper.GetUserAsync(email);
            if (user == null)
            {
                user = new UserEntity
                {
                    FirstName = firstName,
                    LastName = lastName,
                    Email = email,
                    UserName = email,
                    PhoneNumber = phone,
                    Address = address,
                    Document = document,
                    UserType = userType
                };

                await _userHelper.AddUserAsync(user, "123456");
                await _userHelper.AddUserToRoleAsync(user, userType.ToString());
            }
            return user;
        }

        private void AddExpenseType(string Expense)
        {
            _dataContext.ExpenseTypes.Add(new ExpenseTypeEntity
            {
                Expense = Expense
            });
        }

        private async Task CheckTripsAsync(
            UserEntity user1,
            UserEntity user2)
        {
            if (!_dataContext.Trips.Any())
            {
                _dataContext.Trips.Add(new TripEntity
                {
                    Description = "Viaje 1",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMinutes(30),
                    User = user1,
                    City = new CityEntity
                    {
                        City = "Bogota",
                        Country = new CountryEntity
                        {
                            Country = "Colombia"
                        }
                    },
                    TripDetails = new List<TripDetailsEntity>
                    {
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 20000,
                            Description = "Metro",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Transport")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 45000,
                            Description = "Hostal",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Stay")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 35000,
                            Description = "Fast food",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Food")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 150000,
                            Description = "Event",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Representation")
                        }
                    }
                });

                _dataContext.Trips.Add(new TripEntity
                {
                    Description = "Vacations",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMinutes(30),
                    User = user2,
                    City = new CityEntity
                    {
                        City = "Venice",
                        Country = new CountryEntity
                        {
                            Country = "USA"
                        }
                    },
                    TripDetails = new List<TripDetailsEntity>
                    {
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 180000,
                            Description = "Tour",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Transport")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 35000,
                            Description = "Hostal DONT FORGET ME ",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Stay")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 45000,
                            Description = "Dinner",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Food")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 78400,
                            Description = "Disco",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Other")
                        }
                    }
                });


                _dataContext.Trips.Add(new TripEntity
                {
                    Description = "Vacations",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMinutes(30),
                    User = user2,
                    City = new CityEntity
                    {
                        City = "Venice",
                        Country = new CountryEntity
                        {
                            Country = "USA"
                        }
                    },
                    TripDetails = new List<TripDetailsEntity>
                    {
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 250000,
                            Description = "Tour",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Transport")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 85000,
                            Description = "Hostal DONT FORGET ME ",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Stay")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 79000,
                            Description = "Dinner",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Food")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 78400,
                            Description = "Disco",
                            PicturePath = $"~/images/Receipts/receipt.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Others")
                        }
                    }
                });

                await _dataContext.SaveChangesAsync();
            }

        }
    }
}

