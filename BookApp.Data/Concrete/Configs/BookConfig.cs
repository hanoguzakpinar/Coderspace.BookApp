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
    public class BookConfig : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            //PK
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            //Props
            builder.Property(b => b.Title).IsRequired().HasMaxLength(100);
            builder.Property(b => b.PublishDate).IsRequired();
            builder.Property(b => b.PageCount).IsRequired();

            //TableName
            builder.ToTable("Books");

            //Relations
            builder.HasOne(u => u.Genre).WithMany(u => u.Books)
                .HasForeignKey(a => a.GenreID);
            builder.HasOne(u => u.Author).WithMany(u => u.Books)
                .HasForeignKey(a => a.AuthorID);
        }
    }
}
