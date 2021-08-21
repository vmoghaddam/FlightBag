using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace APCore.Models
{
    public partial class IdentityContext : IdentityDbContext
    {
        public IdentityContext()
        {
        }

        public IdentityContext(DbContextOptions<IdentityContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ViewEmployee> ViewEmployees { get; set; }

        //public virtual DbSet<AspNetRole> AspNetRoles { get; set; }
        //public virtual DbSet<AspNetRoleClaim> AspNetRoleClaims { get; set; }
        //public virtual DbSet<AspNetUser> AspNetUsers { get; set; }
        //public virtual DbSet<AspNetUserClaim> AspNetUserClaims { get; set; }
        //public virtual DbSet<AspNetUserLogin> AspNetUserLogins { get; set; }
        //public virtual DbSet<AspNetUserRole> AspNetUserRoles { get; set; }
        //public virtual DbSet<AspNetUserToken> AspNetUserTokens { get; set; }
        //public virtual DbSet<NotificationGroup> NotificationGroups { get; set; }
        //public virtual DbSet<UserExt> UserExts { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //        optionsBuilder.UseSqlServer("Name=ConnectionStrings:EPDB");
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.HasDefaultSchema("dbo")
        //        .HasAnnotation("Relational:Collation", "Persian_100_CI_AI");

        //    //modelBuilder.Entity<AspNetRole>(entity =>
        //    //{
        //    //    entity.ToTable("AspNetRoles", "dbo");

        //    //    entity.HasIndex(e => e.Name, "RoleNameIndex")
        //    //        .IsUnique();

        //    //    entity.Property(e => e.Id).HasMaxLength(128);

        //    //    entity.Property(e => e.Name)
        //    //        .IsRequired()
        //    //        .HasMaxLength(256);
        //    //});

        //    //modelBuilder.Entity<AspNetRoleClaim>(entity =>
        //    //{
        //    //    entity.ToTable("AspNetRoleClaims", "dbo");

        //    //    entity.Property(e => e.Id).HasMaxLength(128);

        //    //    entity.Property(e => e.ClaimType)
        //    //        .HasMaxLength(255)
        //    //        .IsUnicode(false);

        //    //    entity.Property(e => e.ClaimValue)
        //    //        .HasMaxLength(255)
        //    //        .IsUnicode(false);
        //    //});

        //    //modelBuilder.Entity<AspNetUser>(entity =>
        //    //{
        //    //    entity.ToTable("AspNetUsers", "dbo");

        //    //    entity.HasIndex(e => e.UserName, "UserNameIndex")
        //    //        .IsUnique();

        //    //    entity.Property(e => e.Id).HasMaxLength(128);

        //    //    entity.Property(e => e.Email).HasMaxLength(256);

        //    //    entity.Property(e => e.LockoutEndDateUtc).HasColumnType("datetime");

        //    //    entity.Property(e => e.UserName)
        //    //        .IsRequired()
        //    //        .HasMaxLength(256);
        //    //});

        //    //modelBuilder.Entity<AspNetUserClaim>(entity =>
        //    //{
        //    //    entity.ToTable("AspNetUserClaims", "dbo");

        //    //    entity.HasIndex(e => e.UserId, "IX_UserId");

        //    //    entity.Property(e => e.UserId)
        //    //        .IsRequired()
        //    //        .HasMaxLength(128);

        //    //    entity.HasOne(d => d.User)
        //    //        .WithMany(p => p.AspNetUserClaims)
        //    //        .HasForeignKey(d => d.UserId)
        //    //        .HasConstraintName("FK_dbo.AspNetUserClaims_dbo.AspNetUsers_UserId");
        //    //});

        //    //modelBuilder.Entity<AspNetUserLogin>(entity =>
        //    //{
        //    //    entity.HasKey(e => new { e.LoginProvider, e.ProviderKey, e.UserId })
        //    //        .HasName("PK_dbo.AspNetUserLogins");

        //    //    entity.ToTable("AspNetUserLogins", "dbo");

        //    //    entity.HasIndex(e => e.UserId, "IX_UserId");

        //    //    entity.Property(e => e.LoginProvider).HasMaxLength(128);

        //    //    entity.Property(e => e.ProviderKey).HasMaxLength(128);

        //    //    entity.Property(e => e.UserId).HasMaxLength(128);

        //    //    entity.HasOne(d => d.User)
        //    //        .WithMany(p => p.AspNetUserLogins)
        //    //        .HasForeignKey(d => d.UserId)
        //    //        .HasConstraintName("FK_dbo.AspNetUserLogins_dbo.AspNetUsers_UserId");
        //    //});

        //    //modelBuilder.Entity<AspNetUserRole>(entity =>
        //    //{
        //    //    entity.HasKey(e => new { e.UserId, e.RoleId })
        //    //        .HasName("PK_dbo.AspNetUserRoles");

        //    //    entity.ToTable("AspNetUserRoles", "dbo");

        //    //    entity.HasIndex(e => e.RoleId, "IX_RoleId");

        //    //    entity.HasIndex(e => e.UserId, "IX_UserId");

        //    //    entity.Property(e => e.UserId).HasMaxLength(128);

        //    //    entity.Property(e => e.RoleId).HasMaxLength(128);

        //    //    entity.HasOne(d => d.Role)
        //    //        .WithMany(p => p.AspNetUserRoles)
        //    //        .HasForeignKey(d => d.RoleId)
        //    //        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetRoles_RoleId");

        //    //    entity.HasOne(d => d.User)
        //    //        .WithMany(p => p.AspNetUserRoles)
        //    //        .HasForeignKey(d => d.UserId)
        //    //        .HasConstraintName("FK_dbo.AspNetUserRoles_dbo.AspNetUsers_UserId");
        //    //});

        //    //modelBuilder.Entity<AspNetUserToken>(entity =>
        //    //{
        //    //    entity.HasKey(e => new { e.UserId, e.LoginProvider })
        //    //        .HasName("PK__AspNetUs__7AB7EDC57CE24AB4");

        //    //    entity.ToTable("AspNetUserTokens", "dbo");

        //    //    entity.Property(e => e.UserId)
        //    //        .HasMaxLength(500)
        //    //        .IsUnicode(false);

        //    //    entity.Property(e => e.Name)
        //    //        .HasMaxLength(500)
        //    //        .IsUnicode(false);

        //    //    entity.Property(e => e.Value)
        //    //        .HasMaxLength(500)
        //    //        .IsUnicode(false);
        //    //});

        //    modelBuilder.Entity<NotificationGroup>(entity =>
        //    {
        //        entity.ToTable("NotificationGroup", "dbo");

        //        entity.HasIndex(e => e.GroupTitle, "idx_notgrp");

        //        entity.Property(e => e.Id).ValueGeneratedNever();

        //        entity.Property(e => e.GroupTitle)
        //            .IsRequired()
        //            .HasMaxLength(500);

        //        entity.Property(e => e.UserId)
        //            .IsRequired()
        //            .HasMaxLength(128);

        //        entity.HasOne(d => d.User)
        //            .WithMany(p => p.NotificationGroups)
        //            .HasForeignKey(d => d.UserId)
        //            .HasConstraintName("idx_notgrp_user");
        //    });

        //    modelBuilder.Entity<UserExt>(entity =>
        //    {
        //        entity.ToTable("UserExt", "dbo");

        //        entity.Property(e => e.Id).HasMaxLength(128);

        //        entity.Property(e => e.FirstName).HasMaxLength(500);

        //        entity.Property(e => e.LastName).HasMaxLength(500);

        //        entity.HasOne(d => d.IdNavigation)
        //            .WithOne(p => p.UserExt)
        //            .HasForeignKey<UserExt>(d => d.Id)
        //            .HasConstraintName("fk_ext_users");
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
