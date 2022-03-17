using Firm_Register.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Firm_Register.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<Males> Males { get; set; }
        public DbSet<Females> Females { get; set; }
        public DbSet<Family> Family { get; set; }
        public DbSet<Regions> Regions { get; set; }
        public DbSet<Firms> Firms { get; set; }
        public DbSet<Roles> Roles { get; set; }
        public DbSet<People> People { get; set; }
        public DbSet<WorkPlace> WorkPlaces { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<WorkPlace>().HasKey(x => new { x.Person_Id, x.Firm_Id });
        }
    }
}
