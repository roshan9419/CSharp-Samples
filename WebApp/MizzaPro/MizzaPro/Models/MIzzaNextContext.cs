using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MizzaPro.Models
{
    public partial class MIzzaNextContext : DbContext
    {
        public MIzzaNextContext()
        {
        }

        public MIzzaNextContext(DbContextOptions<MIzzaNextContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MizzaSize> MizzaSizes { get; set; }
        public virtual DbSet<MizzaSku> MizzaSkus { get; set; }
        public virtual DbSet<MizzaSkuBasePrice> MizzaSkuBasePrices { get; set; }
        public virtual DbSet<MizzaSkustock> MizzaSkustocks { get; set; }
        public virtual DbSet<MizzaStyle> MizzaStyles { get; set; }
        public virtual DbSet<MizzaToppingSkuprice> MizzaToppingSkuprices { get; set; }
        public virtual DbSet<MizzaToppingSkustock> MizzaToppingSkustocks { get; set; }
        public virtual DbSet<MizzaToppingStyle> MizzaToppingStyles { get; set; }
        public virtual DbSet<MizzaToppingsStyleSku> MizzaToppingsStyleSkus { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
  //              optionsBuilder.UseSqlServer("Server=.;Database=MIzzaNext;User id=sa;password=lsq1234@");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<MizzaSize>(entity =>
            {
                entity.ToTable("MizzaSize");

                entity.Property(e => e.MizzaSizeId)
                    .HasMaxLength(10)
                    .HasColumnName("MizzaSizeID");

                entity.Property(e => e.MizzaSizeName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<MizzaSku>(entity =>
            {
                entity.ToTable("MizzaSKU");

                entity.Property(e => e.MizzaSkuid)
                    .HasMaxLength(10)
                    .HasColumnName("MizzaSKUID");

                entity.Property(e => e.MizzaSizeId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MizzaSizeID");

                entity.Property(e => e.MizzaSkuname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("MizzaSKUName");

                entity.Property(e => e.MizzaStyleId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .HasColumnName("MizzaStyleID");

                entity.HasOne(d => d.MizzaSize)
                    .WithMany(p => p.MizzaSkus)
                    .HasForeignKey(d => d.MizzaSizeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MizzaSKU_MizzaSize");

                entity.HasOne(d => d.MizzaStyle)
                    .WithMany(p => p.MizzaSkus)
                    .HasForeignKey(d => d.MizzaStyleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MizzaSKU_MizzaStyle");
            });

            modelBuilder.Entity<MizzaSkuBasePrice>(entity =>
            {
                entity.HasKey(e => e.Skuid);

                entity.ToTable("MizzaSkuBasePrice");

                entity.Property(e => e.Skuid)
                    .HasMaxLength(10)
                    .HasColumnName("SKUID");

                entity.HasOne(d => d.Sku)
                    .WithOne(p => p.MizzaSkuBasePrice)
                    .HasForeignKey<MizzaSkuBasePrice>(d => d.Skuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MizzaSkuBasePrice_MizzaSKU");
            });

            modelBuilder.Entity<MizzaSkustock>(entity =>
            {
                entity.HasKey(e => e.Skuid);

                entity.ToTable("MizzaSKUStock");

                entity.Property(e => e.Skuid)
                    .HasMaxLength(10)
                    .HasColumnName("SKUID");

                entity.Property(e => e.StockCount)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsFixedLength(true);

                entity.HasOne(d => d.Sku)
                    .WithOne(p => p.MizzaSkustock)
                    .HasForeignKey<MizzaSkustock>(d => d.Skuid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_MizzaSKUStock_MizzaSKU");
            });

            modelBuilder.Entity<MizzaStyle>(entity =>
            {
                entity.ToTable("MizzaStyle");

                entity.Property(e => e.MizzaStyleId)
                    .HasMaxLength(10)
                    .HasColumnName("MizzaStyleID");

                entity.Property(e => e.MizzaStyleName)
                    .IsRequired()
                    .HasMaxLength(50);
            });

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
