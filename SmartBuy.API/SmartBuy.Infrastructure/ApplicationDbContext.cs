using Microsoft.EntityFrameworkCore;
using SmartBuy.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace SmartBuy.Infrastructure
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        private ModelBuilder _modelBuilder { get; set; }

        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            _modelBuilder = modelBuilder;
            base.OnModelCreating(modelBuilder);
            SetProductConfig();
            SetCustomerConfig();
            SetOrderConfig();
            SetOrderDetailConfig();
        }

        public static void ConfigIdAuditEntity<TEntity>(EntityTypeBuilder<TEntity> builder) where TEntity : BaseIdAuditEntity
        {
            builder
                .Property(e => e.Id)
                .HasDefaultValueSql("NEWID()")
                .IsRequired(true);

            builder
                .HasKey(e => e.Id);

            builder.Property(e => e.CreatedBy)
                .HasDefaultValue(Guid.Empty);
            builder
                .Property(e => e.ModifiedBy)
                .HasDefaultValue(Guid.Empty);
            builder
                .Property(x => x.CreatedOn)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");
            builder
                .Property(x => x.ModifiedOn)
                .IsRequired()
                .HasDefaultValueSql("GETUTCDATE()");

        }
        private void SetProductConfig()
        {
            var builder = _modelBuilder.Entity<Product>();

            ConfigIdAuditEntity(builder);

            builder.Property(p => p.Name)
                   .HasMaxLength(100)
                   .IsRequired();            builder.Property(p => p.Description)                .HasColumnType("NVARCHAR(MAX)")                .IsRequired();            builder.Property(p => p.Price)                   .HasColumnType("DECIMAL(18,3)")                   .IsRequired();            builder.Property(p => p.Stock)                .IsRequired();
        }
        private void SetCustomerConfig()
        {
            var builder = _modelBuilder.Entity<Customer>();
            ConfigIdAuditEntity(builder);

            builder.Property(p => p.FirstName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.LastName)
                .HasMaxLength(100)
                .IsRequired();
            builder.Property(p => p.Email)
                .HasMaxLength(50)
                .IsRequired();
            builder.Property(p => p.DOB)
                .IsRequired();
            builder.Property(p => p.Address)
                .HasMaxLength(256)
                .IsRequired();
        }
        private void SetOrderConfig()
        {
            var builder = _modelBuilder.Entity<Order>();
            ConfigIdAuditEntity(builder);

            builder.Property(p => p.CustomerId)
              .IsRequired();

            builder.Property(p => p.TransactionId) //
                .IsRequired();


            builder.HasOne<Customer>() // one entity i.e Customer
               .WithMany() //many entitty i.e Order
               .HasForeignKey(o => o.CustomerId) //fk of Order
               .HasPrincipalKey(c => c.Id) //pk of Customer
               .OnDelete(DeleteBehavior.NoAction);
        }
        private void SetOrderDetailConfig()
        {
            var builder = _modelBuilder.Entity<OrderDetail>();
            ConfigIdAuditEntity(builder);

            builder.Property(p => p.ProductCount)
                .IsRequired();
            builder.Property(p => p.UnitPrice)
                .IsRequired();
            builder.Property(p => p.ProductId)
                .IsRequired();
            builder.Property(p => p.OrderId)
               .IsRequired();


            builder.HasOne<Order>()
               .WithMany()
               .HasPrincipalKey(e => e.Id)
               .HasForeignKey(e => e.OrderId)
               .OnDelete(DeleteBehavior.NoAction);

            builder.HasOne<Product>()
               .WithOne()
               .HasPrincipalKey<Product>(p => p.Id)
               .HasForeignKey<OrderDetail>(od => od.ProductId)
               .OnDelete(DeleteBehavior.NoAction);
        }


    }
}