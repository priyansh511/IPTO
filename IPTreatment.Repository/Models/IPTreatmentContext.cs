using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTreatment.Repository.Models
{
    public partial class IPTreatmentContext : DbContext
    {
        public IPTreatmentContext()
        {

        }
        public IPTreatmentContext(DbContextOptions<IPTreatmentContext> options)  : base(options)
        {
        }
        public DbSet<PackageDetail> PackageDetail { get; set; }
        public DbSet<PatientDetail> PatientDetail { get; set; }
        public DbSet<SpecialistDetail> SpecialistDetail { get; set; }
        public DbSet<IPTreatmentPackage> IPTreatmentPackages { get; set; }
        public DbSet<TreatmentPlan> TreatmentPlan { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB; Database=IPTreatment; integrated security=true");
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
            /*modelBuilder.Entity<TreatmentPlan>(entity =>
            {
                entity.HasOne(d => d.PatientDetail)
                    .WithMany(p => p.TreatmentPlans)
                    .HasForeignKey(d => d.PatientId);

                entity.HasOne(d => d.SpecialistDetail)
                    .WithMany(p => p.TreatmentPlans)
                    .HasForeignKey(d => d.SpecialistId);
            });*/
        }

    }
}
