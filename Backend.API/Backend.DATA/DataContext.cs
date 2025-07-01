using Backend.CORE.entities;
using Microsoft.EntityFrameworkCore;    
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Backend.DATA
{
    public class DataContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=project;Trusted_Connection=True;");
        }


        public DbSet<Users> Users { get; set; } = null!;
        public DbSet<AgeGroups> AgeGroups { get; set; } = null!;
        public DbSet<Activities> Activities { get; set; } = null!;
        public DbSet<Achievements> Achievements { get; set; } = null!;
    }
}
