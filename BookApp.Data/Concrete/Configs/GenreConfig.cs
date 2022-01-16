using BookApp.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BookApp.Data.Concrete.Configs
{
    public class GenreConfig : IEntityTypeConfiguration<Genre>
    {
        public void Configure(EntityTypeBuilder<Genre> builder)
        {
            //PK
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Id).ValueGeneratedOnAdd();

            //Props
            builder.Property(g => g.Name).IsRequired().HasMaxLength(50);

            //TableName
            builder.ToTable("Genres");
        }
    }
}
