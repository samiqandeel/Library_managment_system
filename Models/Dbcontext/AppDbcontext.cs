using Library_mangement_system.Models.Entitys;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace library_management_system
{
    public class AppDbContext : IdentityDbContext<ApplicationUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // DbSets
        public DbSet<Book> Books { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CartItems> CartItems { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItems> OrderItems { get; set; }
        // user 
        public DbSet<Library> Libraries { get; set; } 
        public DbSet<Librian> Librarians { get; set; }
        public DbSet<LibraryCard> LibraryCards { get; set; }
        public DbSet<BuyedBooks> BuyedBooks { get; set; }

    
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);


            //change names table in database

            modelBuilder.Entity<ApplicationUser>()
                .ToTable("Users" , "security");

            modelBuilder.Entity<IdentityRole>()
              .ToTable("Roles" , "security");

            modelBuilder.Entity<IdentityUserRole<string>>()
              .ToTable("UserRole" , "security");

            modelBuilder.Entity<IdentityUserClaim<string>>()
              .ToTable("UserClaims" , "security");

            modelBuilder.Entity<IdentityUserLogin<string>>()
            .ToTable("UserLogins" , "security");

            modelBuilder.Entity<IdentityUserToken<string>>()
            .ToTable("UserToken", "security");

            modelBuilder.Entity<IdentityRoleClaim<string>>()
            .ToTable("RoleClaims", "security");

        }
       
    }

}
