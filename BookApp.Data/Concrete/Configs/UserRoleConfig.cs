using BookApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Concrete.Configs
{
    public class UserRoleConfig : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            //PK
            builder.HasKey(ur => new { ur.RoleId, ur.UserId });

            //TableName
            builder.ToTable("UserRoles");

            //DataSeed
            builder.HasData(new UserRole()
            {
                UserId = 1,
                RoleId = 1
            });
        }
    }
}
