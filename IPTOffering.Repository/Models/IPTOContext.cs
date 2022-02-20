using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Models
{
    public class IPTOContext : DbContext
    {
        public IPTOContext()
        {

        }
        public IPTOContext(DbContextOptions<IPTOContext> options)  : base(options)
        {
        }
        public DbSet<PackageDetail> PackageDetails { get; set; }
        
        public DbSet<SpecialistDetail> SpecialistDetails { get; set; }
        public DbSet<IPTreatmentPackage> IPTreatmentPackages { get; set; }
       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=IPT; integrated security=true");
            }
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Entity<IPTreatmentPackage>()
                .Property(p => p.Ailment)
                .HasConversion(
                    v => v.ToString(),
                    v => (Ailment)Enum.Parse(typeof(Ailment), v));
        }


    }
}
