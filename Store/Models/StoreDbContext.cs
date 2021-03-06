using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Store.Models
{
    public class StoreDbContext : DbContext
    {
        public DbSet<Item> items { get; set; }
        public DbSet<Purchase> purchases { get; set; }

    }
}