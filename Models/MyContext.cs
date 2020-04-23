using System;
using Microsoft.EntityFrameworkCore;

namespace WeddingPlanner.Models {
    public class MyContext : DbContext {
        public MyContext (DbContextOptions options) : base (options) { }

        // this is the variable we will use to connect to the MySQL table, Lizards
        public DbSet<Wedding> Weddings { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Invitation> Invetations { get; set; }
    }
}