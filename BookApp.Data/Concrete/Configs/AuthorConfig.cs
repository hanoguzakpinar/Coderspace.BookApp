using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Concrete.Configs
{
    public class AuthorConfig : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            //PK
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            //Props
            builder.Property(a => a.Name).IsRequired().HasMaxLength(30);
            builder.Property(a => a.Surname).IsRequired().HasMaxLength(30);

            //TableName
            builder.ToTable("Authors");
        }
    }
}
