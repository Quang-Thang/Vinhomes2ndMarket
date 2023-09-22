using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vinhomes2ndMarket.Models;

public partial class Vinhomes2ndMarketContext : DbContext
{
    public Vinhomes2ndMarketContext()
    {
    }

    public Vinhomes2ndMarketContext(DbContextOptions<Vinhomes2ndMarketContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Account> Accounts { get; set; }

    public virtual DbSet<Building> Buildings { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<PostStatus> PostStatuses { get; set; }

    public virtual DbSet<ProductPost> ProductPosts { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Wallet> Wallets { get; set; }

    private string GetConnectionString()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);

        IConfigurationRoot configuration = builder.Build();

        return configuration.GetConnectionString("MyDB");
    }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(GetConnectionString());
        }
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Account>(entity =>
        {
            entity.HasKey(e => e.AccountId).HasName("PK__Account__349DA5A6FC70F3AF");

            entity.ToTable("Account");

            entity.Property(e => e.AccountId).ValueGeneratedNever();
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Fullname).HasMaxLength(255);
            entity.Property(e => e.Password)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Username).HasMaxLength(255);

            entity.HasOne(d => d.Building).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__Account__Buildin__29572725");

            entity.HasOne(d => d.Role).WithMany(p => p.Accounts)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Account__RoleId__286302EC");
        });

        modelBuilder.Entity<Building>(entity =>
        {
            entity.HasKey(e => e.BuildingId).HasName("PK__Building__5463CDC47161127A");

            entity.ToTable("Building");

            entity.Property(e => e.BuildingId).ValueGeneratedNever();
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A0BC070EC56");

            entity.ToTable("Category");

            entity.Property(e => e.CategoryId).ValueGeneratedNever();
            entity.Property(e => e.Name).HasMaxLength(255);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Order__C3905BCF43CA488A");

            entity.ToTable("Order");

            entity.Property(e => e.OrderId).ValueGeneratedNever();
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Orders)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Order__AccountId__36B12243");

            entity.HasOne(d => d.ProductPost).WithMany(p => p.Orders)
                .HasForeignKey(d => d.ProductPostId)
                .HasConstraintName("FK__Order__ProductPo__35BCFE0A");
        });

        modelBuilder.Entity<PostStatus>(entity =>
        {
            entity.HasKey(e => e.PostStatusId).HasName("PK__PostStat__B8333F044C829571");

            entity.ToTable("PostStatus");

            entity.Property(e => e.PostStatusId).ValueGeneratedNever();
            entity.Property(e => e.Payment)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsFixedLength();

            entity.HasOne(d => d.ProductPost).WithMany(p => p.PostStatuses)
                .HasForeignKey(d => d.ProductPostId)
                .HasConstraintName("FK__PostStatu__Produ__398D8EEE");
        });

        modelBuilder.Entity<ProductPost>(entity =>
        {
            entity.HasKey(e => e.ProductPostId).HasName("PK__ProductP__BA6CEEAFB0B2D3AE");

            entity.ToTable("ProductPost");

            entity.Property(e => e.ProductPostId).ValueGeneratedNever();
            entity.Property(e => e.CreateAt).HasColumnType("datetime");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ImageUrl)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.LastUpdateAt).HasColumnType("datetime");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Status)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Title)
                .HasMaxLength(255)
                .IsUnicode(false);

            entity.HasOne(d => d.Account).WithMany(p => p.ProductPosts)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__ProductPo__Accou__30F848ED");

            entity.HasOne(d => d.Building).WithMany(p => p.ProductPosts)
                .HasForeignKey(d => d.BuildingId)
                .HasConstraintName("FK__ProductPo__Build__31EC6D26");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductPosts)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__ProductPo__Categ__32E0915F");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE1A5833E338");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).ValueGeneratedNever();
            entity.Property(e => e.Name)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Wallet>(entity =>
        {
            entity.HasKey(e => e.WalletId).HasName("PK__Wallet__84D4F90E50CCB8BA");

            entity.ToTable("Wallet");

            entity.Property(e => e.WalletId).ValueGeneratedNever();
            entity.Property(e => e.Balance).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Account).WithMany(p => p.Wallets)
                .HasForeignKey(d => d.AccountId)
                .HasConstraintName("FK__Wallet__AccountI__2C3393D0");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
