﻿using Microsoft.EntityFrameworkCore;
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
        //public DbSet<Customer> Customers { get; set; }
        //public DbSet<Cart> Carts { get; set; }
        //public DbSet<Order> Orders { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetProductConfig();
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

        //builder
        //    .Property(e => e.USI)
        //    .HasMaxLength(100)
        //    .IsRequired();
        //builder
        //    .Property(e => e.ABN)
        //    .HasMaxLength(11)
        //    .IsRequired();
        //builder
        //    .Property(e => e.ElectronicServiceAddressAlias)
        //    .HasMaxLength(256)
        //    .IsRequired();
        //builder
        //    .Property(e => e.AccountName)
        //    .HasMaxLength(100)
        //    .IsRequired();
        //builder
        //    .Property(e => e.AccountNumber)
        //    .HasMaxLength(16)
        //    .IsRequired();
        //builder
        //    .Property(e => e.EData)
        //    .IsRequired();
        //builder.HasOne<Employee>()
        //   .WithMany()
        //   .HasPrincipalKey(e => e.Id)
        //   .HasForeignKey(e => e.EmployeeId)
        //   .OnDelete(DeleteBehavior.NoAction);
        //builder.HasOne<Company>()
        //    .WithMany()
        //    .HasPrincipalKey(e => e.Id)
        //    .HasForeignKey(e => e.CompanyId)
        //    .OnDelete(DeleteBehavior.NoAction);
        //builder.HasOne<LookUp>()
        //    .WithMany()
        //    .HasPrincipalKey(e => e.Id)
        //    .HasForeignKey(e => e.TypeId)
        //    .OnDelete(DeleteBehavior.NoAction);
    }
    /*
     1.CRUD - product,cart,customer,purchase
     2.JWT token with identity tables
     */
}
