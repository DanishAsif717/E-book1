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

    public virtual DbSet<SubCategory> SubCategories { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=DESKTOP-A0HEMGG\\SQLEXPRESS;initial catalog=e-project;user id=sa;password=danish; TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC0704D2DF8B");

            entity.ToTable("Book");

            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Lounch).HasColumnName("lounch");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SubId).HasColumnName("sub_id");

            entity.HasOne(d => d.Cat).WithMany(p => p.Books)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_Tocategory");

            entity.HasOne(d => d.Sub).WithMany(p => p.Books)
                .HasForeignKey(d => d.SubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Book_ToSubcategory");
        });

        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC079D546D9F");

            entity.ToTable("category");

            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Name).HasColumnName("name");
        });

        modelBuilder.Entity<CdandDvd>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07BC496814");

            entity.ToTable("CdandDvd");

            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Lounch).HasColumnName("lounch");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SubId).HasColumnName("sub_id");

            entity.HasOne(d => d.Cat).WithMany(p => p.CdandDvds)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CdandDvd_Tocategory");

            entity.HasOne(d => d.Sub).WithMany(p => p.CdandDvds)
                .HasForeignKey(d => d.SubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_CdandDvd_ToSubcategory");
        });

        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.CustomerId).HasName("PK__Customer__A4AE64B8F9EF835B");

            entity.HasIndex(e => e.Email, "UQ__Customer__A9D105346AE2CD4D").IsUnique();

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
            entity.HasKey(e => e.Faqid).HasName("PK__FAQs__4B89D1E27336B71C");

            entity.ToTable("FAQs");

            entity.Property(e => e.Faqid).HasColumnName("FAQID");
            entity.Property(e => e.Answer).HasColumnType("text");
            entity.Property(e => e.Question).HasColumnType("text");
        });

        modelBuilder.Entity<FeedbackAndQuery>(entity =>
        {
            entity.HasKey(e => e.FeedbackId).HasName("PK__Feedback__6A4BEDF6D187333C");

            entity.Property(e => e.FeedbackId).HasColumnName("FeedbackID");
            entity.Property(e => e.CustomerId).HasColumnName("CustomerID");
            entity.Property(e => e.DateResponded).HasColumnType("date");
            entity.Property(e => e.DateSubmitted).HasColumnType("date");
            entity.Property(e => e.Message).HasColumnType("text");
            entity.Property(e => e.Response).HasColumnType("text");

            entity.HasOne(d => d.Customer).WithMany(p => p.FeedbackAndQueries)
                .HasForeignKey(d => d.CustomerId)
                .HasConstraintName("FK__FeedbackA__Custo__5DCAEF64");
        });

        modelBuilder.Entity<Manufacturer>(entity =>
        {
            entity.HasKey(e => e.ManufacturerId).HasName("PK__Manufact__357E5CA1422DE83C");

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
            entity.HasKey(e => e.OrderId).HasName("PK__Orders__C3905BAF298F7B05");

            entity.HasIndex(e => e.OrderNumber, "UQ__Orders__CAC5E7435432E5A9").IsUnique();

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
                .HasConstraintName("FK__Orders__Customer__60A75C0F");
        });

        modelBuilder.Entity<OrderDetail>(entity =>
        {
            entity.HasKey(e => e.OrderDetailId).HasName("PK__OrderDet__D3B9D30CC9AB6489");

            entity.Property(e => e.OrderDetailId).HasColumnName("OrderDetailID");
            entity.Property(e => e.OrderId).HasColumnName("OrderID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.UnitPrice).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderDetails)
                .HasForeignKey(d => d.OrderId)
                .HasConstraintName("FK__OrderDeta__Order__5EBF139D");
        });

        modelBuilder.Entity<Payment>(entity =>
        {
            entity.HasKey(e => e.PaymentId).HasName("PK__Payments__9B556A58E6A41617");

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
                .HasConstraintName("FK__Payments__OrderI__619B8048");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Products__3214EC075F681A3D");

            entity.Property(e => e.Author).HasColumnName("author");
            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Description).HasColumnName("description");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Lounch).HasColumnName("lounch");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Price).HasColumnName("price");
            entity.Property(e => e.SubId).HasColumnName("sub_id");

            entity.HasOne(d => d.Cat).WithMany(p => p.Products)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_Tocategory");

            entity.HasOne(d => d.Sub).WithMany(p => p.Products)
                .HasForeignKey(d => d.SubId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Products_ToSubcategory");
        });

        modelBuilder.Entity<Stationary>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__stationa__3214EC07BD4D6949");

            entity.ToTable("stationary");

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
                .HasConstraintName("FK_stationary_ToCategory");
        });

        modelBuilder.Entity<SubCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07C2FFD13C");

            entity.ToTable("SubCategory");

            entity.Property(e => e.CatId).HasColumnName("cat_id");
            entity.Property(e => e.Code).HasColumnName("code");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");

            entity.HasOne(d => d.Cat).WithMany(p => p.SubCategories)
                .HasForeignKey(d => d.CatId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_SubCategory_ToCategory");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__tmp_ms_x__3214EC07F7F8AE06");

            entity.ToTable("user");

            entity.Property(e => e.ConfirmPassword).HasColumnName("confirm_password");
            entity.Property(e => e.CreatedBy)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("created_by");
            entity.Property(e => e.Email).HasColumnName("email");
            entity.Property(e => e.Image).HasColumnName("image");
            entity.Property(e => e.Name).HasColumnName("name");
            entity.Property(e => e.Password).HasColumnName("password");
            entity.Property(e => e.Role).HasColumnName("role");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
