using e_shift_app.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace e_shift_app.db
{
    public class AppDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<Load> Loads { get; set; }
        public DbSet<TransportUnit> TransportUnits { get; set; }
        public DbSet<Lorry> Lorries { get; set; }
        public DbSet<Driver> Drivers { get; set; }
        public DbSet<Assistant> Assistants { get; set; }
        public DbSet<Container> Containers { get; set; }
        public DbSet<Admins> Admins { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuring relationships

            // Customer ↔ Job (One-to-Many)
            modelBuilder.Entity<Job>()
                .HasOne(j => j.Customer)
                .WithMany(c => c.Jobs)
                .HasForeignKey(j => j.CustomerId);

            // Job ↔ Load (One-to-Many)
            modelBuilder.Entity<Load>()
                .HasOne(l => l.Job)
                .WithMany(j => j.Loads)
                .HasForeignKey(l => l.JobId);

            // TransportUnit ↔ Job (One-to-Many)
            modelBuilder.Entity<Job>()
                .HasOne(l => l.TransportUnit)
                .WithMany(t => t.Jobs)
                .HasForeignKey(l => l.TransportUnitId);

            // TransportUnit ↔ Lorry, Driver, Assistant, Container (One-to-One)
            modelBuilder.Entity<TransportUnit>()
                .HasOne(t => t.Lorry)
                .WithOne(l => l.TransportUnit)
                .HasForeignKey<TransportUnit>(t => t.LorryId);

            modelBuilder.Entity<TransportUnit>()
                .HasOne(t => t.Driver)
                .WithOne(d => d.TransportUnit)
                .HasForeignKey<TransportUnit>(t => t.DriverId);

            modelBuilder.Entity<TransportUnit>()
                .HasOne(t => t.Assistant)
                .WithOne(a => a.TransportUnit)
                .HasForeignKey<TransportUnit>(t => t.AssistantId);

            modelBuilder.Entity<TransportUnit>()
                .HasOne(t => t.Container)
                .WithOne(c => c.TransportUnit)
                .HasForeignKey<TransportUnit>(t => t.ContainerId);

            // Ensure default value for Job.Status
            modelBuilder.Entity<Job>()
                .Property(j => j.Status)
                .HasDefaultValue(e_shift_app.models.JobStatus.Submitted);
        }
    }
}
