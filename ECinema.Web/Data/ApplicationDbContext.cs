using ECinema.Web.Models.Domain;
using ECinema.Web.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace ECinema.Web.Data
{
    public class ApplicationDbContext : IdentityDbContext<ECinemaUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public virtual DbSet<Tickets> Tickets { get; set; }
        public virtual DbSet<ShoppingCart> ShoppingCarts { get; set; }
        public virtual DbSet<TicketsInShoppingCart> TicketsInShoppingCarts { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderForShoppingCart> OrderForShoppingCarts { get; set; }
       


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Tickets>()
                .Property(z => z.Id)
                .ValueGeneratedOnAdd();

            builder.Entity<ShoppingCart>()
               .Property(z => z.Id)
               .ValueGeneratedOnAdd();

            builder.Entity<TicketsInShoppingCart>()
                .HasKey(z => new { z.TicketID, z.ShoppingCartID });

            builder.Entity<TicketsInShoppingCart>()
                .HasOne(z => z.Ticket)
                .WithMany(z => z.TicketsInShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartID);

            builder.Entity<TicketsInShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.TicketsInShoppingCarts)
                .HasForeignKey(z => z.TicketID);

            builder.Entity<ShoppingCart>()
                .HasOne<ECinemaUser>(z => z.Owner)
                .WithOne(z => z.UserCart)
                .HasForeignKey<ShoppingCart>(z => z.OwnerID);

            builder.Entity<OrderForShoppingCart>()
                .HasKey(z => new { z.OrderID, z.ShoppingCartID });

            builder.Entity<OrderForShoppingCart>()
                .HasOne(z => z.Order)
                .WithMany(z => z.OrderForShoppingCarts)
                .HasForeignKey(z => z.ShoppingCartID);

            builder.Entity<OrderForShoppingCart>()
                .HasOne(z => z.ShoppingCart)
                .WithMany(z => z.OrderForShoppingCarts)
                .HasForeignKey(z => z.OrderID);

           
            


        }
    }
}
