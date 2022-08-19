using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;

namespace MVCAuthIndividual.Models
{
    public partial class MizzaContext : DbContext
    {
        public MizzaContext()
            : base("name=MizzaConnection")
        {
        }

        public virtual DbSet<MizzaSize> MizzaSizes { get; set; }
        public virtual DbSet<MizzaSKU> MizzaSKUs { get; set; }
        public virtual DbSet<MizzaSkuBasePrice> MizzaSkuBasePrices { get; set; }
        public virtual DbSet<MizzaSKUStock> MizzaSKUStocks { get; set; }
        public virtual DbSet<MizzaStyle> MizzaStyles { get; set; }
        public virtual DbSet<MizzaToppingSKUPrice> MizzaToppingSKUPrices { get; set; }
        public virtual DbSet<MizzaToppingSKUStock> MizzaToppingSKUStocks { get; set; }
        public virtual DbSet<MizzaToppingsStyleSKU> MizzaToppingsStyleSKUs { get; set; }
        public virtual DbSet<MizzaToppingStyle> MizzaToppingStyles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MizzaSize>()
                .HasMany(e => e.MizzaSKUs)
                .WithRequired(e => e.MizzaSize)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MizzaSKU>()
                .HasOptional(e => e.MizzaSkuBasePrice)
                .WithRequired(e => e.MizzaSKU);

            modelBuilder.Entity<MizzaSKU>()
                .HasOptional(e => e.MizzaSKUStock)
                .WithRequired(e => e.MizzaSKU);

            modelBuilder.Entity<MizzaSKUStock>()
                .Property(e => e.StockCount)
                .IsFixedLength();

            modelBuilder.Entity<MizzaStyle>()
                .HasMany(e => e.MizzaSKUs)
                .WithRequired(e => e.MizzaStyle)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<MizzaToppingsStyleSKU>()
                .HasOptional(e => e.MizzaToppingSKUPrice)
                .WithRequired(e => e.MizzaToppingsStyleSKU);

            modelBuilder.Entity<MizzaToppingsStyleSKU>()
                .HasOptional(e => e.MizzaToppingSKUStock)
                .WithRequired(e => e.MizzaToppingsStyleSKU);

            modelBuilder.Entity<MizzaToppingStyle>()
                .HasMany(e => e.MizzaToppingsStyleSKUs)
                .WithRequired(e => e.MizzaToppingStyle)
                .WillCascadeOnDelete(false);
        }
    }
}
