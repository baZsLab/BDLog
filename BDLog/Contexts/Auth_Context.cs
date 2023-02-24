using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BDPFMA.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

#nullable disable

namespace BDPFMA.Contexts
{
    public partial class Auth_Context : IdentityDbContext
    {
        public Auth_Context()
        {
        }

        public Auth_Context(DbContextOptions<Auth_Context> options)
            : base(options)
        {
        }
        
        public virtual DbSet<BdpfUsername> BdpfUsernames { get; set; }
        public virtual DbSet<BdpfUserrole> BdpfUserroles { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    if (!optionsBuilder.IsConfigured)
        //    {
        //    }
        //}

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.HasDefaultSchema("TESTDB")
        //        .HasAnnotation("Relational:Collation", "USING_NLS_COMP");

        //    modelBuilder.Entity<BdpfUsername>(entity =>
        //    {
        //        entity.HasKey(e => e.UserId)
        //            .HasName("BDPF_USERNAMES_PK");

        //        entity.Property(e => e.UserId).HasPrecision(9);

        //        entity.Property(e => e.UserName).IsUnicode(false);

        //        entity.Property(e => e.UserRole).HasPrecision(9);

        //        entity.HasOne(d => d.UserRoleNavigation)
        //            .WithMany(p => p.BdpfUsernames)
        //            .HasForeignKey(d => d.UserRole)
        //            .HasConstraintName("BDPF_ROLE_BDPF_USERNAMES");
        //    });

        //    modelBuilder.Entity<BdpfUserrole>(entity =>
        //    {
        //        entity.HasKey(e => e.RoleId)
        //            .HasName("BDPF_USERROLES_PK");

        //        entity.Property(e => e.RoleId).HasPrecision(9);

        //        entity.Property(e => e.RoleName).IsUnicode(false);
        //    });

        //    OnModelCreatingPartial(modelBuilder);
        //}

        //partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
