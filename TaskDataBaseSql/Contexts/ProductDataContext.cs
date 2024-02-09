using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using TaskDataBaseSql.ProductsEntities;

namespace TaskDataBaseSql.Contexts;

public partial class ProductDataContext : DbContext
{
    public ProductDataContext()
    {
    }

    public ProductDataContext(DbContextOptions<ProductDataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<CategoriesEntity> CategoriesEntities { get; set; }

    public virtual DbSet<ClientsEntity> ClientsEntities { get; set; }

    public virtual DbSet<DirectionsEntity> DirectionsEntities { get; set; }

    public virtual DbSet<ProductsEntity> ProductsEntities { get; set; }

    public virtual DbSet<ReadersEntity> ReadersEntities { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Users\\User\\source\\repos\\TaskDataBaseSql\\TaskDataBaseSql\\Data\\ProductDatabase.mdf;Integrated Security=True;Connect Timeout=30");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<CategoriesEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Categori__3214EC0725A5404E");

            entity.ToTable("CategoriesEntity");
        });

        modelBuilder.Entity<ClientsEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ClientsE__3214EC07908FC175");

            entity.ToTable("ClientsEntity");

            entity.HasOne(d => d.Direction).WithMany(p => p.ClientsEntities)
                .HasForeignKey(d => d.DirectionId)
                .HasConstraintName("FK__ClientsEn__Direc__3D5E1FD2");

            entity.HasOne(d => d.Reader).WithMany(p => p.ClientsEntities)
                .HasForeignKey(d => d.ReaderId)
                .HasConstraintName("FK__ClientsEn__Reade__3C69FB99");
        });

        modelBuilder.Entity<DirectionsEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Directio__3214EC07814B9AF1");

            entity.ToTable("DirectionsEntity");
        });

        modelBuilder.Entity<ProductsEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC0727FD36A6");

            entity.ToTable("ProductsEntity");

            entity.HasOne(d => d.Category).WithMany(p => p.ProductsEntities)
                .HasForeignKey(d => d.CategoryId)
                .HasConstraintName("FK__ProductsE__Categ__403A8C7D");
        });

        modelBuilder.Entity<ReadersEntity>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__ReadersE__3214EC07DF5719A6");

            entity.ToTable("ReadersEntity");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
