using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Job_Application_Tracker.Models.Entities
{
    public class JATContext : DbContext
    {
        public static string CONNSTRING { get; set; }

        public JATContext()
        {

        }

        public JATContext(DbContextOptions<JATContext> options)
            : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql(CONNSTRING);
            }
        }
        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>(e =>
            {
                e.ToTable("Companies");
                e.HasKey(pk => pk.Id);
                e.Property(pk => pk.Id).ValueGeneratedOnAdd();
                e.Property(p => p.CompanyName).HasMaxLength(64).IsRequired();
                e.Property(p => p.DoNotApply).IsRequired().HasDefaultValue(false);
                e.Property(p => p.k401Match).HasColumnName("401kMatch");
            });

            modelBuilder.Entity<Contact>(e =>
            {
                e.ToTable("Contacts");
                e.HasKey(pk => pk.Id);
                e.Property(pk => pk.Id).ValueGeneratedOnAdd();
                e.HasOne(cont => cont.Company)
                    .WithMany(comp => comp.Contacts)
                    .HasForeignKey(k => k.CompanyId)
                    .OnDelete(DeleteBehavior.Cascade);
            });
        }
    }
}
