using BookApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Concrete.Configs
{
    public class RoleClaimConfig : IEntityTypeConfiguration<RoleClaim>
    {
        public void Configure(EntityTypeBuilder<RoleClaim> builder)
        {
            //PK
            builder.HasKey(rc => rc.Id);

            //TableName
            builder.ToTable("RoleClaims");
        }
    }
}
