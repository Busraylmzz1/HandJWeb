using HandJWebApp.Models.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HandJWebApp.Models.DataContext
{
    public class BusinessWebDBContext: DbContext
    {
        public BusinessWebDBContext():base ("BusinessDB")
        {
              
        }
        public DbSet<Admin> Admin { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<AboutUs> AboutUs { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<Communication> Communication { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Identity> Identity { get; set; }
        public DbSet<Slider> Slider { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Customer> Customer{ get; set; }

    }
}