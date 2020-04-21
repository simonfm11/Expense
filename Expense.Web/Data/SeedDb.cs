using Expense.Web.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Expense.Web.Data
{
    public class SeedDb
    {
        private readonly DataContext _dataContext;

        public SeedDb(
            DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckRolesAsync();
            await CheckExpenseTypeAsync();
            await CheckUserAsync("1111", "Simon", "simonfm11@hotmail.com", "320 154 84 69", "Cra 11 # 54 -85", UserType.Admin);
            UserEntity user1 = await CheckUserAsync("2222", "Daniel", "lopez", "daniel@yopmail.com", "323 548 98 78", "La tierra del olvido", UserType.Employee);
            UserEntity user2 = await CheckUserAsync("3333", "Valentina", "trujillo", "valentina@yopmail.com", "312 768 32 45", "La playa con carabobo", UserType.Employee);
            await CheckTripsAsync(user1, user2);
        }

        public async Task SeedAsync()
        {
            await _dataContext.Database.EnsureCreatedAsync();
            await CheckTripsAsync();
        }


        private async Task CheckExpenseTypeAsync()
        {
            if (!_dataContext.ExpenseTypes.Any())
            {
                AddExpenseType("Comida");
                AddExpenseType("Transporte");
                AddExpenseType("Estadia");
                AddExpenseType("Representacion");
                AddExpenseType("Varios");
            }
            await _dataContext.SaveChangesAsync();
        }

        public async Task CheckRolesAsync()
        {
            await _userHelper.CheckRoleAsync(UserType.Admin.ToString());
            await _userHelper.CheckRoleAsync(UserType.Employee.ToString());
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
                            PicturePath = $"~/images/vouncher/VouncherTaxi.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Transport")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 180000,
                            Description = "Stayd hotal HOI AN",
                            PicturePath = $"~/images/vouncher/VouncherStayed.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Stay")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 75000,
                            Description = "Day Food",
                            PicturePath = $"~/images/vouncher/VouncherFood.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Food")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 320000,
                            Description = "Annual Conference",
                            PicturePath = $"~/images/vouncher/VouncherRepr.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Representation")
                        }
                    }
                });

                _dataContext.Trips.Add(new TripEntity
                {
                    Description = "Holiday Travel",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMinutes(30),
                    User = user2,
                    City = new CityEntity
                    {
                        City = "Santa Marta",
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
                            Amount = 89000,
                            Description = "Taxi to airport",
                            PicturePath = $"~/images/vouncher/VouncherTaxi.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Transport")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 670000,
                            Description = "Stayd hotal Sweet Water",
                            PicturePath = $"~/images/vouncher/VouncherStayed.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Stay")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 76000,
                            Description = "Day Food",
                            PicturePath = $"~/images/vouncher/VouncherFood.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Food")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 655000,
                            Description = "Beach games",
                            PicturePath = $"~/images/vouncher/VouncherRepr.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Others")
                        }
                    }
                });


                _dataContext.Trips.Add(new TripEntity
                {
                    Description = "Holiday Travel",
                    StartDate = DateTime.UtcNow,
                    EndDate = DateTime.UtcNow.AddMinutes(30),
                    User = user1,
                    City = new CityEntity
                    {
                        City = "Cartagena",
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
                            Amount = 98000,
                            Description = "Taxi to airport",
                            PicturePath = $"~/images/vouncher/VouncherTaxi.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Transport")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 678000,
                            Description = "Stayd hotal Sweet Water",
                            PicturePath = $"~/images/vouncher/VouncherStayed.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Stay")
                        },
                        new TripDetailsEntity   
                        {
                            Date = DateTime.UtcNow,
                            Amount = 76564,
                            Description = "Day Food",
                            PicturePath = $"~/images/vouncher/VouncherFood.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Food")
                        },
                        new TripDetailsEntity
                        {
                            Date = DateTime.UtcNow,
                            Amount = 65333,
                            Description = "Beach games",
                            PicturePath = $"~/images/vouncher/VouncherRepr.jpg",
                            ExpenseType = await _dataContext.ExpenseTypes.FirstOrDefaultAsync(e => e.Expense == "Others")
                        }
                    }
                });

                await _dataContext.SaveChangesAsync();
            }

        }
    }
}

