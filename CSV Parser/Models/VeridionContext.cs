using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CSV_Parser.Models;

public partial class VeridionContext : DbContext
{
    public VeridionContext()
    {
    }

    public VeridionContext(DbContextOptions<VeridionContext> options)
        : base(options)
    {
    }

    public virtual DbSet<AllInfo> AllInfos { get; set; }

    public virtual DbSet<Facebook> Facebooks { get; set; }

    public virtual DbSet<Google> Googles { get; set; }

    public virtual DbSet<Website> Websites { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=localhost;Database=veridion;User Id=sa;Password=satefut.12;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<AllInfo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__AllInfo__3213E83FBFE077AF");

            entity.ToTable("AllInfo");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Category).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Country_Code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .HasColumnName("Country_Name");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Domain).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.FacebookId).HasColumnName("facebook_id");
            entity.Property(e => e.GoogleId).HasColumnName("google_id");
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PhoneCountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Phone_Country_Code");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Region_Code");
            entity.Property(e => e.RegionName)
                .HasMaxLength(100)
                .HasColumnName("Region_Name");
            entity.Property(e => e.WebsiteId).HasColumnName("website_id");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<Facebook>(entity =>
        {
            entity.ToTable("Facebook");

            entity.HasIndex(e => e.Phone, "idx_facebook");

            entity.HasIndex(e => e.Name, "idx_facebook_name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Categories).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Country_Code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .HasColumnName("Country_Name");
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.Domain).HasMaxLength(255);
            entity.Property(e => e.Email).HasMaxLength(255);
            entity.Property(e => e.Link).HasMaxLength(2083);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.PageType)
                .HasMaxLength(50)
                .HasColumnName("Page_Type");
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PhoneCountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Phone_Country_Code");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Region_Code");
            entity.Property(e => e.RegionName)
                .HasMaxLength(100)
                .HasColumnName("Region_Name");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<Google>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_google");

            entity.ToTable("Google");

            entity.HasIndex(e => e.Phone, "idx_Google");

            entity.HasIndex(e => e.Name, "idx_google_name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Address).HasMaxLength(500);
            entity.Property(e => e.Category).HasMaxLength(500);
            entity.Property(e => e.City).HasMaxLength(100);
            entity.Property(e => e.CountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Country_Code");
            entity.Property(e => e.CountryName)
                .HasMaxLength(100)
                .HasColumnName("Country_Name");
            entity.Property(e => e.Domain).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);
            entity.Property(e => e.Phone).HasMaxLength(20);
            entity.Property(e => e.PhoneCountryCode)
                .HasMaxLength(2)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Phone_Country_Code");
            entity.Property(e => e.RawAddress)
                .HasMaxLength(500)
                .HasColumnName("Raw_Address");
            entity.Property(e => e.RawPhone)
                .HasMaxLength(20)
                .HasColumnName("Raw_Phone");
            entity.Property(e => e.RegionCode)
                .HasMaxLength(4)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("Region_Code");
            entity.Property(e => e.RegionName)
                .HasMaxLength(100)
                .HasColumnName("Region_Name");
            entity.Property(e => e.Text).HasColumnType("text");
            entity.Property(e => e.ZipCode)
                .HasMaxLength(20)
                .HasColumnName("Zip_Code");
        });

        modelBuilder.Entity<Website>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK_website");

            entity.ToTable("Website");

            entity.HasIndex(e => e.Phone, "idx_Website");

            entity.HasIndex(e => e.LegalName, "idx_website_legal_name");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DomainSuffix)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("domain_suffix");
            entity.Property(e => e.Language)
                .HasMaxLength(10)
                .HasColumnName("language");
            entity.Property(e => e.LegalName)
                .HasMaxLength(255)
                .HasColumnName("legal_name");
            entity.Property(e => e.MainCity)
                .HasMaxLength(100)
                .HasColumnName("main_city");
            entity.Property(e => e.MainCountry)
                .HasMaxLength(100)
                .HasColumnName("main_country");
            entity.Property(e => e.MainRegion)
                .HasMaxLength(100)
                .HasColumnName("main_region");
            entity.Property(e => e.Phone)
                .HasMaxLength(50)
                .HasColumnName("phone");
            entity.Property(e => e.RootDomain)
                .HasMaxLength(255)
                .HasColumnName("root_domain");
            entity.Property(e => e.SCategory)
                .HasMaxLength(500)
                .HasColumnName("s_category");
            entity.Property(e => e.SiteName)
                .HasMaxLength(255)
                .HasColumnName("site_name");
            entity.Property(e => e.Tld)
                .HasMaxLength(10)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("tld");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
