using DataModel.Configuration;
using DataModel.Identity.Configuration;
using DataModel.Identity.Models;
using DataModel.Models.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DataModel
{
    public class MMSDbContext : IdentityDbContext<ApplicationUser>
    {

        public MMSDbContext(DbContextOptions<MMSDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfiguration(new RoleConfiguration());
            modelBuilder.ApplyConfiguration(new NotifyHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new NotifyItemConfiguration());
            modelBuilder.ApplyConfiguration(new StoreHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new StoreItemConfiguration());
            modelBuilder.ApplyConfiguration(new RequestHeaderConfiguration());
            modelBuilder.ApplyConfiguration(new RequestItemConfiguration());
            modelBuilder.ApplyConfiguration(new HrConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerConfiguration());
            modelBuilder.ApplyConfiguration(new CustomerWarrantyConfiguration());
            modelBuilder.Entity<ApplicationUser>(entity =>
           {
               entity.ToTable(name: "Users");
           });

            modelBuilder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Roles");
            });
            modelBuilder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            modelBuilder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            modelBuilder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UsersTokens");
            });

        }

        public DbSet<NotifyHeader> NotifyHeaders { get; set; }
        public DbSet<NotifyItem> NotifyItems { get; set; }
        public DbSet<StoreHeader> StoreHeaders { get; set; }
        public DbSet<StoreItem> StoreItems { get; set; }
        public DbSet<RequestHeader> RequestHeaders { get; set; }
        public DbSet<RequestItem> RequestItems { get; set; }
        public DbSet<Approve> Approves { get; set; }
        public DbSet<Distribute> Distributes { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerWarranty> CustemerWarranties { get; set; }
        public DbSet<ReturnHeader> ReturnHeaders { get; set; }
        public DbSet<ReturnItem> ReturnItems { get; set; }
        public DbSet<HR> Hrs { get; set; }


    }
}