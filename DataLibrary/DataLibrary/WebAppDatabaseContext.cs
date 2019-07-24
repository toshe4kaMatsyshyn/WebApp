using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace DataLibrary
{
    public partial class WebAppDatabaseContext : DbContext
    {
        public WebAppDatabaseContext()
        {
        }

        public WebAppDatabaseContext(DbContextOptions<WebAppDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Brands> Brands { get; set; }
        public virtual DbSet<DeliveredBrands> DeliveredBrands { get; set; }
        public virtual DbSet<ProducedBrands> ProducedBrands { get; set; }
        public virtual DbSet<Terminal> Terminal { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=DESKTOP-GN3L1JT\\SQLEXPRESS;Database=WebAppDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Brands>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);
            });

            modelBuilder.Entity<DeliveredBrands>(entity =>
            {
                entity.HasKey(e => e.ProducedBrandsId);

                entity.Property(e => e.ProducedBrandsId)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.HasOne(d => d.ProducedBrands)
                    .WithOne(p => p.DeliveredBrands)
                    .HasForeignKey<DeliveredBrands>(d => d.ProducedBrandsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DeliveredBrands_ProduceBrands");
            });

            modelBuilder.Entity<ProducedBrands>(entity =>
            {
                entity.HasKey(e => e.BrandsId);

                entity.Property(e => e.BrandsId)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.YearOfProduced).HasColumnType("date");

                entity.HasOne(d => d.Brands)
                    .WithOne(p => p.ProducedBrands)
                    .HasForeignKey<ProducedBrands>(d => d.BrandsId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ProducedBrands_Brands");
            });

            modelBuilder.Entity<Terminal>(entity =>
            {
                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .ValueGeneratedNever();

                entity.Property(e => e.Name).HasMaxLength(10);
            });
        }
    }
}
