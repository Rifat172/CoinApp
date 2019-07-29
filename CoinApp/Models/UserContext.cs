using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace CoinApp.Models
{
    public class UserContext : DbContext
    {
        public DbSet<User> Users { get; set; }
    }
}