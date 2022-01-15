using BookApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Concrete.Configs
{
    public class UserClaimConfig : IEntityTypeConfiguration<UserClaim>
    {
        public void Configure(EntityTypeBuilder<UserClaim> builder)
        {
            //PK
            builder.HasKey(uc => uc.Id);

            //TableName
            builder.ToTable("UserClaims");
        }
    }
}
