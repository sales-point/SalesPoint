using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SalesPoint.Data.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace SalesPoint.Data
{
    public class DataContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public DbSet<ApplicationUser> Users { get; set; }
        public DbSet<ApplicationRole> Roles { get; set; }
        public DbSet<MenuItem> MenuItems { get; set; }
        public DbSet<MenuType> MenuTypes { get; set; }
        public DbSet<MenuSet> MenuSets { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Order> Orders { get; set; }

        public DataContext(DbContextOptions<DataContext> options)
           : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            //optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<MenuItemMenuSet>()
                .HasKey(mm => new { mm.MenuItemId, mm.MenuSetId });

            builder.Entity<MenuItemMenuSet>()
                .HasOne(mm => mm.MenuItem)
                .WithMany(ms => ms.ItemSets)
                .HasForeignKey(ms => ms.MenuItemId);

            builder.Entity<MenuItemMenuSet>()
                .HasOne(mm => mm.MenuSet)
                .WithMany(ms => ms.SetItems)
                .HasForeignKey(ms => ms.MenuSetId);
        }
    }
}
