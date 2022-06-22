using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataModel.Identity.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
              new IdentityRole
              {
                  Name = "mmd",
                  NormalizedName = "MMD"
              },
              new IdentityRole
              {
                  Name = "Admin",
                  NormalizedName = "Admin"
              },
              new IdentityRole
              {
                  Name = "storeman",
                  NormalizedName = "storeman"
              }

            );
        }
    }
}
