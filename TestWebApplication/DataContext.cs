using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestWebApplication.Models;

namespace TestWebApplication
{
    public class DataContext : DbContext
    {
        public DbSet<Students> Students { get; set; }
    }
}