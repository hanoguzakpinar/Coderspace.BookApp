using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using BookApp.Entities;

namespace BookApp.Data.Concrete.Configs
{
    public class RoleConfig : IEntityTypeConfiguration<Role>
    {
        public void Configure(EntityTypeBuilder<Role> builder)
        {
            //PK
            builder.HasKey(r => r.Id);

            //? Index for "normalized" role name to allow efficient lookups
            builder.HasIndex(r => r.NormalizedName).HasDatabaseName("RoleNameIndex").IsUnique();

            //Props
            builder.Property(r => r.ConcurrencyStamp).IsConcurrencyToken();
            builder.Property(r => r.Name).HasMaxLength(100);
            builder.Property(r => r.NormalizedName).HasMaxLength(100);

            //TableName
            builder.ToTable("Roles");

            //Relations
            builder.HasMany<UserRole>().WithOne().HasForeignKey(ur => ur.RoleId).IsRequired();
            builder.HasMany<RoleClaim>().WithOne().HasForeignKey(rc => rc.RoleId).IsRequired();

            //DataSeed
            builder.HasData(
                new Role
                {
                    Id = 1,
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                },
                new Role
                {
                    Id = 2,
                    Name = "Member",
                    NormalizedName = "MEMBER",
                    ConcurrencyStamp = Guid.NewGuid().ToString()
                }
                );
        }
    }
}
