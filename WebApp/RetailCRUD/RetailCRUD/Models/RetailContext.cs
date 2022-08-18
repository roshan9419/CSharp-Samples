using Microsoft.EntityFrameworkCore;

namespace RetailCRUD.Models
{
    public partial class RetailContext : DbContext
    {
        public RetailContext() { }

        public RetailContext(DbContextOptions<RetailContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(16)
                    .HasColumnName("CategoryID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50); // HasColumnName("Name") not required if column name is same as field
            });

            modelBuilder.Entity<Product>(entity =>
            {
                entity.ToTable("Product");

                entity.Property(e => e.ProductId)
                    .HasMaxLength(16)
                    .HasColumnName("ProductID");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Description)
                    .HasMaxLength(200);

                entity.Property(e => e.CategoryId)
                    .IsRequired()
                    .HasMaxLength(16)
                    .HasColumnName("CategoryID");

                entity.HasOne(p => p.Category)
                    .WithMany(c => c.Products)
                    .HasForeignKey(p => p.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Category_Product");
            });

            // modelBuilder.Entity<ProductStock>(entity =)
        }
    }
}
