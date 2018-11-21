using Microsoft.EntityFrameworkCore;
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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            LinkUsersTableToUsers(modelBuilder);
            base.OnModelCreating(modelBuilder);
        }

        private static void LinkUsersTableToUsers(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .ToTable("Users", "USR")
                .HasKey(k => k.ID);
            modelBuilder.Entity<User>()
                .Property(p => p.ID).HasColumnName("User_ID");
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
                .Property(p => p.Role).HasColumnName("User_Role")

        }
    }
}
