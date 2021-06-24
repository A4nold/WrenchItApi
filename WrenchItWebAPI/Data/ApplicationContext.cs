using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WrenchItWebAPI.Models;

namespace WrenchItWebAPI.Data
{
    public class ApplicationContext : DbContext

    {
        public ApplicationContext(DbContextOptions options)
            : base(options)
        {

        }

        public DbSet<Service> Services { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
        }

       
        
    }
}
