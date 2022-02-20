using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Models
{
    public class InsuranceClaimDbContext : DbContext
    {
        public InsuranceClaimDbContext()
        {

        }

        public InsuranceClaimDbContext(DbContextOptions<InsuranceClaimDbContext> options) : base(options)
        {

        }

        public DbSet<InitiateClaim> InitiateClaims { get; set; }
        public DbSet<InsurerDetail> InsurerDetails { get; set; }
        public DbSet<PatientDetail> PatientDetail { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlan { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
            .Entity<InitiateClaim>()
            .Property(p => p.Ailment)
            .HasConversion(
            v => v.ToString(),
            v => (Ailment)Enum.Parse(typeof(Ailment), v));

            modelBuilder
            .Entity<PatientDetail>()
            .Property(p => p.Ailment)
            .HasConversion(
            v => v.ToString(),
            v => (Ailment)Enum.Parse(typeof(Ailment), v));
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
       //     IConfigurationRoot configuration = new ConfigurationBuilder().SetBasePath(AppDomain.CurrentDomain.BaseDirectory).AddJsonFile("appsettings.json").Build();
            optionsBuilder.UseSqlServer("data source = (localdb)\\MSSQLLocalDB; database = InsuranceClaim; integrated security = true");
                //configuration.GetConnectionString(/*"InsuranceClaimDbContext"*/));
        }
    }
}
