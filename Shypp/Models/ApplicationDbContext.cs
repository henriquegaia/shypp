using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity.EntityFramework;


namespace Shypp.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }
        public DbSet<Request> Requests { get; set; }
        public DbSet<Photo> Photos { get; set; }

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
            
        //    modelBuilder.Entity<Request>()
        //        .HasRequired(r => r.AddressOrigin)
        //        .WithMany(a => a.RequestsOrigin)
        //        .HasForeignKey(r => r.AddressOriginId);

        //    modelBuilder.Entity<Request>()
        //        .HasRequired(r => r.AddressDestiny)
        //        .WithMany(a => a.RequestsDestiny)
        //        .HasForeignKey(r => r.AddressDestinyId);

        //    base.OnModelCreating(modelBuilder);
        //}

    }
}