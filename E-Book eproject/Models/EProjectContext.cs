using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace E_Book_eproject.Models;

public partial class EProjectContext : DbContext
{
    public EProjectContext()
    {
    }

    public EProjectContext(DbContextOptions<EProjectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<CdandDvd> CdandDvds { get; set; }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Faq> Faqs { get; set; }

    public virtual DbSet<FeedbackAndQuery> FeedbackAndQueries { get; set; }

    public virtual DbSet<Manufacturer> Manufacturers { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<OrderDetail> OrderDetails { get; set; }

    public virtual DbSet<Payment> Payments { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Stationary> Stationaries { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=.;initial catalog=e-project;user id=sa;password=aptech; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.AdminId).HasName("PK__Admin__719FE4E886F97552");

            entity.ToTable("Admin");

            entity.HasIndex(e => e.Username, "UQ__Admin__536C85E4C1BDF424").IsUnique();

            entity.HasIndex(e => e.Email, "UQ__Admin__A9D10534418ED01B").IsUnique();

            entity.Property(e => e.AdminId).HasColumnName("AdminID");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.PasswordHash)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Username)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC079DD3ED57");

            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Lounch)
                .HasColumnType("date")
                .HasColumnName("lounch");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Cat).WithMany(p => p.Books)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Books_category");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3213E83F1C3201A9");

            entity.ToTable("Category");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Descrition).HasColumnName("descrition");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<CdandDvd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC072419A9C9");

            entity.ToTable("CDandDVD");

            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Lounch)
                .HasColumnType("date")
                .HasColumnName("lounch");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");

            entity.HasOne(d => d.Cat).WithMany(p => p.CdandDvds)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CDandDVD_Tocategory");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8270F5FD9");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D105349512FDFC").IsUnique();

            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.Address)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.DistanceKm)
                .HasColumnType("decimal(5, 2)")
                .HasColumnName("DistanceKM");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Faq>(entity =>
        {
            entity.HasKey(e => e.Faqid).HasName("PK__FAQs__4B89D1E28E48764C");

            entity.ToTable("FAQs");

            entity.Property(e => e.Faqid).HasColumnName("FAQID");
            entity.Property(e => e.Answer).HasColumnType("text");
            entity.Property(e => e.Question).HasColumnType("text");
        });

        modelBuilder.Entity<FeedbackAndQuery>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF63CA011A0");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateResponded).HasColumnType("date");
            entity.Property(e => e.DateSubmitted).HasColumnType("date");
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.Response).HasColumnType("text");

            entity.HasOne(d => d.Customer).WithMany(p => p.FeedbackAndQueries)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__FeedbackA__Custo__37A5467C");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__Manufact__357E5CA1892760A0");

            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.Acronym)
                .HasMaxLength(3)
                .IsUnicode(false);
            entity.Property(e => e.ContactInfo)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ManufacturerName)
                .HasMaxLength(255)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAFDE1C12A6");

            entity.HasIndex(e => e.OrderNumber, "UQ__Orders__CAC5E7434F52C68B").IsUnique();

            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DeliveryDistance).HasColumnType("decimal(5, 2)");
            entity.Property(e => e.OrderDate).HasColumnType("date");
            entity.Property(e => e.OrderNumber)
                .HasMaxLength(8)
                .IsUnicode(false);
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.TotalAmount).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Customer).WithMany(p => p.Orders)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__Orders__Customer__3A81B327");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30C83F869E1");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__38996AB5");

            entity.HasOne(d => d.Product).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__OrderDeta__Produ__398D8EEE");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58CA19770E");

            entity.Property(e => e.PaymentId).HasColumnName("PaymentID");
            entity.Property(e => e.Amount).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.PaymentDate).HasColumnType("date");
            entity.Property(e => e.PaymentStatus)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.PaymentType)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Order).WithMany(p => p.Payments)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__Payments__OrderI__3B75D760");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Products__B40CC6EDF7B0D14E");

            entity.HasIndex(e => e.ProductCode, "UQ__Products__2F4E024FDB654FB7").IsUnique();

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ManufacturerId).HasColumnName("ManufacturerID");
            entity.Property(e => e.Price).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.ProductCode)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.ProductName)
                .HasMaxLength(255)
                .IsUnicode(false);
            entity.Property(e => e.ReleaseDate).HasColumnType("date");
            entity.Property(e => e.SubCategory)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Version)
                .HasMaxLength(20)
                .IsUnicode(false);

            entity.HasOne(d => d.Manufacturer).WithMany(p => p.Products)
                .HasForeignKey(d => d.ManufacturerId)
                .HasConstraintName("FK__Products__Manufa__3C69FB99");
        });

        modelBuilder.Entity<Stationary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07B4AA4522");

            entity.ToTable("Stationary");

            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.Qty).HasColumnName("qty");

            entity.HasOne(d => d.Cat).WithMany(p => p.Stationaries)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Stationary_Tocategory");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
