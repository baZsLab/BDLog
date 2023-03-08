using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using BDELog.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using System.Reflection.Emit;

#nullable disable

namespace BDELog.Contexts
{
    public class ApplicationUser: IdentityUser<int>
    {
        public string FullUser { get; set; }
    }
    public partial class Auth_Context : IdentityDbContext<ApplicationUser,IdentityRole<int>, int>
    {

        public Auth_Context(DbContextOptions<Auth_Context> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    => optionsBuilder
            .UseOracle()
            .UseUpperCaseNamingConvention();




        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);



            //builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.ToTable(name: "USR_USER");
            });
            builder.Entity<IdentityRole<int>>(entity =>
            {
                entity.ToTable(name: "USR_ROLE");
            });
            builder.Entity<IdentityUserRole<int>>(entity =>
            {
                entity.ToTable("USR_USERROLES");
            });
            builder.Entity<IdentityUserClaim<int>>(entity =>
            {
                entity.ToTable("USR_USERCLAIMS");
            });
            builder.Entity<IdentityUserLogin<int>>(entity =>
            {
                entity.ToTable("USR_USERLOGINS");
            });
            builder.Entity<IdentityRoleClaim<int>>(entity =>
            {
                entity.ToTable("USR_ROLECLAIMS");
            });
            builder.Entity<IdentityUserToken<int>>(entity =>
            {
                entity.ToTable("USR_USERTOKENS");
            });






        }

    }
}
