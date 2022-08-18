using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MizzaToppingsCore.DataModel.Models
{
    public partial class MizzaToppingContext : DbContext
    {
        public MizzaToppingContext()
        {
        }

        public MizzaToppingContext(DbContextOptions<MizzaToppingContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MizzaToppingSkuprice> MizzaToppingSkuprices { get; set; }
        public virtual DbSet<MizzaToppingSkustock> MizzaToppingSkustocks { get; set; }
        public virtual DbSet<MizzaToppingStyle> MizzaToppingStyles { get; set; }
        public virtual DbSet<MizzaToppingsStyleSku> MizzaToppingsStyleSkus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //              optionsBuilder.UseSqlServer("Server=.;Database=MizzaTopping;User id=sa;password=lsq1234@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MizzaToppingSkuprice>(entity =>
            {
                entity.HasKey(e => new { e.ToppingStyleId, e.Skuid });

                entity.ToTable("MizzaToppingSKUPrice");

                entity.Property(e => e.ToppingStyleId)
                    .HasMaxLength(10)
                    .HasColumnName("ToppingStyleID");

                entity.Property(e => e.Skuid)
                    .HasMaxLength(10)
                    .HasColumnName("SKUID");

                entity.HasOne(d => d.MizzaToppingsStyleSku)
                    .WithOne(p => p.MizzaToppingSkuprice)
                    .HasForeignKey<MizzaToppingSkuprice>(d => new { d.ToppingStyleId, d.Skuid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MizzaToppingSKUPrice_MizzaToppingsStyleSKU");
            });

            modelBuilder.Entity<MizzaToppingSkustock>(entity =>
            {
                entity.HasKey(e => new { e.ToppingStyleId, e.Skuid });

                entity.ToTable("MizzaToppingSKUStock");

                entity.Property(e => e.ToppingStyleId)
                    .HasMaxLength(10)
                    .HasColumnName("ToppingStyleID");

                entity.Property(e => e.Skuid)
                    .HasMaxLength(10)
                    .HasColumnName("SKUID");

                entity.HasOne(d => d.MizzaToppingsStyleSku)
                    .WithOne(p => p.MizzaToppingSkustock)
                    .HasForeignKey<MizzaToppingSkustock>(d => new { d.ToppingStyleId, d.Skuid })
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MizzaToppingSKUStock_MizzaToppingsStyleSKU");
            });

            modelBuilder.Entity<MizzaToppingStyle>(entity =>
            {
                entity.HasKey(e => e.ToppingStyleId);

                entity.ToTable("MizzaToppingStyle");

                entity.Property(e => e.ToppingStyleId)
                    .HasMaxLength(10)
                    .HasColumnName("ToppingStyleID");

                entity.Property(e => e.ToppingName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MizzaToppingsStyleSku>(entity =>
            {
                entity.HasKey(e => new { e.ToppingStyleId, e.ToppingSkuid })
                    .HasName("PK_MizzaToppingsStyleSKU_1");

                entity.ToTable("MizzaToppingsStyleSKU");

                entity.Property(e => e.ToppingStyleId)
                    .HasMaxLength(10)
                    .HasColumnName("ToppingStyleID");

                entity.Property(e => e.ToppingSkuid)
                    .HasMaxLength(10)
                    .HasColumnName("ToppingSKUID");

                entity.HasOne(d => d.ToppingStyle)
                    .WithMany(p => p.MizzaToppingsStyleSkus)
                    .HasForeignKey(d => d.ToppingStyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MizzaToppingsStyleSKU_MizzaToppingStyle");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
