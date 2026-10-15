using E_Commerce_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace E_Commerce_WebAPI.Data
{
    public class AppDbContext:DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<User> Users { get; set; }  
        public DbSet<Category> Categories { get; set; }  
        public DbSet<Product> Products { get; set; }  
        public DbSet<Order> Orders { get; set; }  
        public DbSet<OrderItem> OrderItems { get; set; }

        //Fluent API 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Relationships
            modelBuilder.Entity<Product>()
                .HasOne(p=>p.Category)
                .WithMany(c=>c.Products)
                .HasForeignKey(p=>p.CategoryId);

            modelBuilder.Entity<Order>()
               .HasOne(o => o.Customer)
               .WithMany(u=>u.Orders)
               .HasForeignKey(o=>o.CustomerId);

            modelBuilder.Entity<OrderItem>()
               .HasOne(ot => ot.Order)
               .WithMany(o=>o.Items)
               .HasForeignKey(ot=>ot.OrderId);

            modelBuilder.Entity<OrderItem>()
               .HasOne(ot=>ot.Product)
               .WithMany(p=>p.Items)
               .HasForeignKey(ot=>ot.ProductId);

            //Data seeding

            modelBuilder.Entity<User>()
                .HasData(
                new User
                {
                    Id=1,
                    FullName= "Ahmed Hassan",
                    Email= "ahmed@example.com",
                    PasswordHash= "123456A",
                    Role= "Customer"
                },
                new User
                   {
                    Id = 2,
                    FullName = "Mona Ali",
                    Email = "mona@example.com",
                    PasswordHash = "123456M",
                    Role = "Customer"
                   },
                new User
                      {
                     Id = 3,
                     FullName = "Store Admin",
                     Email = "admin@example.com",
                     PasswordHash = "123456Adm",
                     Role = "Admin"
                      }
                );

            modelBuilder.Entity<Category>()
                .HasData(
                new Category
                {
                    Id = 1,
                    Name= "Electronics",
                    Description= "Electronic devices and accessories"
                },   new Category
                {
                    Id = 2,
                    Name= "Books",
                    Description= "Programming and technical books"
                },   new Category
                {
                    Id = 3,
                    Name= "Accessories",
                    Description= "Everyday computer accessories"
                }
                );

            modelBuilder.Entity<Product>()
                .HasData(
                new Product
                {
                    Id = 1,
                    Name = "Wireless Mouse",
                    Price = 450,
                    StockQuantity = 25,
                    CategoryId=1
                },
                new Product
                       {
                           Id = 2,
                           Name = "Headphones",
                           Price = 1200,
                           StockQuantity = 12,
                           CategoryId = 2
                },
                new Product
                {
                    Id = 3,
                    Name= "C++ Fundamentals",
                    Price=350,
                    StockQuantity=30,
                    CategoryId=3
                    
                }             
                );

            modelBuilder.Entity<Order>()
                .HasData(
                new Order
                {
                    Id = 1,
                    OrderDate = new DateTime(2026, 10, 1),
                    Status="Completed",
                    TotalAmount=800,
                    CustomerId=1,
                },
                  new Order
                  {
                      Id = 2,
                      OrderDate = new DateTime(2026, 10, 10),
                      Status = "Pending",
                      TotalAmount = 1200,
                      CustomerId=2
                  },
                    new Order
                    {
                        Id = 3,
                        OrderDate = new DateTime(2026, 10, 12),
                        Status = "Cancdelled",
                        TotalAmount = 350,
                        CustomerId = 3
                    }
                );

            modelBuilder.Entity<OrderItem>()
                .HasData(
                new OrderItem
                {
                    Id = 1,
                    Quantity = 1,
                    UnitPrice=450
                    ,OrderId=1,
                    ProductId=1,
                } ,
                new OrderItem
                {
                    Id = 2,
                    Quantity = 1,
                    UnitPrice=350,
                    OrderId=2,
                    ProductId=2
                },
                new OrderItem
                {
                    Id = 3,
                    Quantity = 1,
                    UnitPrice=1200,
                    OrderId=3,
                    ProductId=3
                }
                );
        }

    }
}
