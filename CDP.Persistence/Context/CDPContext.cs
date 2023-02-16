using CDP.Domain.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CDP.Domain;
using System.Runtime.Intrinsics.Arm;

namespace CDP.Persistence.Context
{
    public class CDPContext : IdentityDbContext<User, Role, int,
                                                        IdentityUserClaim<int>, UserRole, IdentityUserLogin<int>,
                                                        IdentityRoleClaim<int>, IdentityUserToken<int>>
    {
        public CDPContext(DbContextOptions<CDPContext> options) : base(options) { }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Farm> Farms { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Planting> Plantings { get; set; }
        public DbSet<Plot> Plots { get; set; }
        public DbSet<Seed> Seeds { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>(userRole =>
            {
                userRole.HasOne(ur => ur.Role)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.RoleId)
                        .IsRequired();

                userRole.HasOne(ur => ur.User)
                        .WithMany(r => r.UserRoles)
                        .HasForeignKey(ur => ur.UserId)
                .IsRequired();
            });

            modelBuilder.Entity<PlantingPlot>()
                            .HasKey(PP => new { PP.PlantingId, PP.PlotId });

            modelBuilder.Entity<Farm>()
                .HasMany(f => f.Plots)
                .WithOne(p => p.Farm)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
