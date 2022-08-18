using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MizzaItemsCore.DataModel.Models
{
    public partial class MizzaItemContext : DbContext
    {
        public MizzaItemContext()
        {
        }

        public MizzaItemContext(DbContextOptions<MizzaItemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<MizzaSize> MizzaSizes { get; set; }
        public virtual DbSet<MizzaSku> MizzaSkus { get; set; }
        public virtual DbSet<MizzaSkuBasePrice> MizzaSkuBasePrices { get; set; }
        public virtual DbSet<MizzaSkustock> MizzaSkustocks { get; set; }
        public virtual DbSet<MizzaStyle> MizzaStyles { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Server=.;Database=MizzaItem;User id=sa;password=lsq1234@;");
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

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
