using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Text;

namespace _06_EF_API_Home_Work_Store
{
    
    public class StoreDb : DbContext
    {
        public StoreDb()
        {
            //this.Database.EnsureDeleted();
            //this.Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer(@"
                Data Source=(localdb)\MSSQLLocalDB;
                Initial Catalog=Store_FluentAPI_06_Home_Work;
                Integrated Security=True;
                Connect Timeout=2;
            ");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // ================= COUNTRY =================
            modelBuilder.Entity<Country>().HasKey(c => c.NumCountry);

            modelBuilder.Entity<Country>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);

            // ================= CITY =================      
            modelBuilder.Entity<City>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(100);

            // ================= SHOP =================

            modelBuilder.Entity<Shop>()
                .Property(s => s.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("ShopName");

            modelBuilder.Entity<Shop>()
                .Property(s => s.Address)
                .IsRequired()
                .HasMaxLength(200);

            modelBuilder.Entity<Shop>()
                .Property(s => s.Website)
                .HasMaxLength(150);
    
            // ================= POSITION =================
            modelBuilder.Entity<Position>().ToTable("Positions");

            modelBuilder.Entity<Position>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(50);

            // ================= WORKER - EMPLOYEES =================
            modelBuilder.Entity<Worker>().ToTable("Employees");
            modelBuilder.Entity<Worker>().HasKey(w => w.UniqNumb);

            modelBuilder.Entity<Worker>()
                .Property(w => w.Name)
                .IsRequired()
                .HasMaxLength(50)
                .HasColumnName("FirstName");

            modelBuilder.Entity<Worker>()
                .Property(w => w.Surname)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<Worker>()
                .Property(w => w.Email)
                .HasMaxLength(150);

            modelBuilder.Entity<Worker>()
                .Property(w => w.Salary)
                .HasColumnType("decimal(10,2)");

            // ================= CATEGORY =================
            modelBuilder.Entity<Category>().ToTable("TypeProduct");

            modelBuilder.Entity<Category>()
                .Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(50);
            
            // ================= PRODUCT =================
            modelBuilder.Entity<Product>().ToTable("Products");

            modelBuilder.Entity<Product>()
                .Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(100);

            modelBuilder.Entity<Product>()
                .Property(p => p.Price)
                .HasColumnType("decimal(10,2)"
            );

            // ========= CONNECTIONS ========

            modelBuilder.Entity<Country>()
                .HasMany(c => c.Cities)
                .WithOne(c => c.Country)
                .HasForeignKey(c => c.CountryKey);

            modelBuilder.Entity<Shop>()
                .HasMany(s => s.Workers)
                .WithOne(w => w.Shop)
                .HasForeignKey(w => w.ShopId);

            modelBuilder.Entity<Position>()
                .HasMany(p => p.Workers)
                .WithOne(w => w.Position)
                .HasForeignKey(w => w.PositionId);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Products)
                .WithOne(p => p.Category)
                .HasForeignKey(p => p.CategoryId);


            // ================= SEEDER =================
            modelBuilder.SeedCountries();
            modelBuilder.SeedCities();
            modelBuilder.SeedPositions();
            modelBuilder.SeedShops();
            modelBuilder.SeedWorkers();
            modelBuilder.SeedCategories();
            modelBuilder.SeedProducts();
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Shop> Shops { get; set; }
        public DbSet<Worker> Workers { get; set; }
        public DbSet<Position> Positions { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
    }

    // ===================== ENTITIES =====================

    public class Country
    {
        public int NumCountry { get; set; }
        public string Name { get; set; }
        public ICollection<City> Cities { get; set; }
    }

    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountryKey { get; set; }
        public Country Country { get; set; }
        public ICollection<Shop> Shops { get; set; }
    }

    public class Shop
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }
        public City City { get; set; }
        public int? ParkingArea { get; set; }
        public string Website { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }

    public class Worker
    {
        public int UniqNumb { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public decimal Salary { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
        public int ShopId { get; set; }
        public Shop Shop { get; set; }
    }

    public class Position
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Worker> Workers { get; set; }
    }

    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float? Discount { get; set; }
        public int? CategoryId { get; set; }
        public Category Category { get; set; }
        public int Quantity { get; set; }
        public bool IsInStock { get; set; }
    }
}

