using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _06_EF_API_Home_Work_Store
{
    public static class DbInitializeStore
    {
        public static void SeedCountries(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country 
                {
                    NumCountry = 1,
                    Name = "Ukraine" 
                },
                new Country 
                { 
                    NumCountry = 2, 
                    Name = "USA" 
                }
            );
        }

        public static void SeedCities(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<City>().HasData(
                new City 
                { 
                    Id = 1,
                    Name = "Novoselytsia",
                    CountryKey = 1 
                },
                new City 
                { 
                    Id = 2,
                    Name = "Boyany",
                    CountryKey = 1 
                },
                new City 
                {
                    Id = 3,
                    Name = "New York",
                    CountryKey = 2 
                }
            );
        }

        public static void SeedPositions(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Position>().HasData(
                new Position 
                { 
                    Id = 1,
                    Name = "Manager"
                },
                new Position 
                { Id = 2,
                    Name = "Cashier" 
                },
                new Position 
                {
                    Id = 3,
                    Name = "Seller"
                }
            );
        }

        public static void SeedShops(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Shop>().HasData(
                new Shop 
                { Id = 1,
                    Name = "HotPies",
                    Address = "St.Bandery 13",
                    CityId = 1,
                    ParkingArea = 20,
                    Website = "https://hotpies.ua" 
                },
                new Shop 
                { 
                    Id = 2,
                    Name = "SausageMeat",
                    Address = "Shevchenka 5",
                    CityId = 2, ParkingArea = 10,
                    Website = "https://sausagemeat.us" 
                }
            );
        }

        public static void SeedWorkers(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Worker>().HasData(
                new Worker 
                { 
                    UniqNumb = 1,
                    Name = "Ivan",
                    Surname = "Rotko", 
                    Salary = 2000000,
                    Email = "ivan@gmail.com",
                    PhoneNumber = "050-123-456",
                    PositionId = 1,
                    ShopId = 1 
                },
                new Worker 
                {
                    UniqNumb = 2,
                    Name = "Elon", 
                    Surname = "Musk",
                    Salary = 15000,
                    Email = "elon@gmail.com",
                    PhoneNumber = "205-555-777",
                    PositionId = 2,
                    ShopId = 2
                }
            );
        }

        public static void SeedCategories(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category 
                {
                    Id = 1,
                    Name = "Delicacy"
                },
                new Category 
                {
                    Id = 2,
                    Name = "Food"
                }
            );
        }

        public static void SeedProducts(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().HasData(
                new Product
                {
                    Id = 1,
                    Name = "CheryCake",
                    Price = 300,
                    Discount = 5,
                    CategoryId = 1,
                    Quantity = 10,
                    IsInStock = true 
                },
                new Product 
                {
                    Id = 2,
                    Name = "PorcYong",
                    Price = 25,
                    Discount = null,
                    CategoryId = 2,
                    Quantity = 100,
                    IsInStock = true 
                }
            );
        }
    }
}
