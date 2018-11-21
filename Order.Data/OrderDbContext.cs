using Microsoft.EntityFrameworkCore;
using Order_Domain.Orders;
using Order_Domain.items;
using Order_Domain.Users;
using System;

namespace Order.Data
{
    public class OrderDbContext : DbContext
    {
        public OrderDbContext(DbContextOptions options) : base(options)
        {

        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Items> Items { get; set; }
        public virtual DbSet<OrderClass> Orders { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LinkUsersTableToUsers(modelBuilder);
            LinkItemToTableItem(modelBuilder);
            LinkOrderToTableOrder(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void LinkUsersTableToUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users", "USR")
                .HasKey(k => k.UserID);
            modelBuilder.Entity<User>()
                .Property(p => p.UserID).HasColumnName("User_ID");
            modelBuilder.Entity<User>()
                .Property(p => p.Firstname).HasColumnName("User_FirstName");
            modelBuilder.Entity<User>()
                .Property(p => p.LastName).HasColumnName("User_LastName");
            modelBuilder.Entity<User>()
                .Property(p => p.Email).HasColumnName("User_Email");
            modelBuilder.Entity<User>()
                .Property(p => p.Number).HasColumnName("User_Number");
            modelBuilder.Entity<User>()
                .Property(p => p.Password).HasColumnName("User_Password");
            modelBuilder.Entity<User>()
                .Property(p => p.PostalCode).HasColumnName("User_Zip");
            modelBuilder.Entity<User>()
                .Property(p => p.Street).HasColumnName("User_Street");
            modelBuilder.Entity<User>()
                .Property(p => p.RoleOfUserID).HasColumnName("User_RoleID");


            modelBuilder.Entity<PhoneNumber>()
                .ToTable("PhoneNumbers", "USR")
                .HasKey(ph => new
                {
                    ph.UserID,
                    ph.Number
                });

            modelBuilder.Entity<PhoneNumber>()
                .HasOne(us => us.User)
                .WithMany()
                .HasForeignKey(ph => ph.UserID)
                .IsRequired();

            modelBuilder.Entity<PhoneNumber>()
                .Property(p => p.Number).HasColumnName("PhoneNumber");
            modelBuilder.Entity<PhoneNumber>()
                .Property(p => p.UserID).HasColumnName("User_ID");

            modelBuilder.Entity<Roles>()
                .ToTable("Roles", "USR")
                .HasKey(rol => rol.RolesId);

            modelBuilder.Entity<Roles>()
                .HasOne(ro => ro.User)
                .WithOne()
                .IsRequired();

            modelBuilder.Entity<Roles>()
                .Property(p => p.RolesId).HasColumnName("User_RoleID");
            modelBuilder.Entity<Roles>()
                .Property(p => p.Role).HasColumnName("User_Role");

        }

        private static void LinkItemToTableItem(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Items>()
                .ToTable("Item", "IT")
                .HasKey(key => key.ItemID);

            modelBuilder.Entity<Items>()
                .Property(p => p.ItemID).HasColumnName("Item_ID");
            modelBuilder.Entity<Items>()
                .Property(p => p.Name).HasColumnName("Item_Name");
            modelBuilder.Entity<Items>()
                .Property(p => p.Price).HasColumnName("Item_Price");
            modelBuilder.Entity<Items>()
                .Property(p => p.Amount).HasColumnName("Item_Amount");
            modelBuilder.Entity<Items>()
                .Property(p => p.Description).HasColumnName("Item_Description");
            modelBuilder.Entity<Items>()
                .Property(p => p.ItemIsInStockID).HasColumnName("Item_InStock");
        }

        private static void LinkOrderToTableOrder(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderClass>()
                .ToTable("Orders", "ORD")
                .HasKey(key => key.OrderID);

            modelBuilder.Entity<OrderClass>()
            .Property(p => p.OrderID).HasColumnName("Order_ID");
            modelBuilder.Entity<OrderClass>()
                .Property(p => p.CustomerID).HasColumnName("User_ID");
            modelBuilder.Entity<OrderClass>()
                .Property(p => p.TotalPrice).HasColumnName("Order_TotalPrice");
            modelBuilder.Entity<OrderClass>()
                .Property(p => p.OrderDate).HasColumnName("Order_Date");

            modelBuilder.Entity<OrderClass>()
                .HasOne(mem => mem.User)
                .WithMany()
                .HasForeignKey(key => key.CustomerID)
                .IsRequired();

            modelBuilder.Entity<ItemGroup>()
                .ToTable("ItemGroup", "ORD")
                .HasKey(key => new
                {
                    key.OrderID,
                    key.ItemId
                });

            modelBuilder.Entity<ItemGroup>()
                .Property(p => p.OrderID).HasColumnName("Order_ID");
            modelBuilder.Entity<ItemGroup>()
                .Property(p => p.ItemId).HasColumnName("Item_ID");
            modelBuilder.Entity<ItemGroup>()
                .Property(p => p.Price).HasColumnName("ItemGroup_Price");
            modelBuilder.Entity<ItemGroup>()
                .Property(p => p.ShippingDate).HasColumnName("ItemGroup_ShippingDate");
            modelBuilder.Entity<ItemGroup>()
                .Property(p => p.Amount).HasColumnName("ItemGroup_Amount");

            modelBuilder.Entity<OrderClass>()
                .HasMany(ord => ord.ItemGroups)
                .WithOne(o => o.Order)
                .HasForeignKey(key => key.OrderID)
                .IsRequired();

            modelBuilder.Entity<ItemGroup>()
                .HasOne(it => it.Item)
                .WithOne(m => m.ItemGroup)
                .HasForeignKey<Items>(key => key.ItemID)
                .IsRequired();

               

        }
    }
}
