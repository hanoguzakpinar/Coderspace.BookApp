using BookApp.Data.Concrete.Configs;
using BookApp.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Concrete.Contexts
{
    public class BookContext : IdentityDbContext<User, Role, int, UserClaim, UserRole, UserLogin, RoleClaim, UserToken>
    {
        public BookContext(DbContextOptions<BookContext> options) : base(options)
        {
        }

        public DbSet<Genre> Genres { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //Configs
            builder.ApplyConfiguration(new RoleConfig());
            builder.ApplyConfiguration(new UserConfig());
            builder.ApplyConfiguration(new RoleClaimConfig());
            builder.ApplyConfiguration(new UserClaimConfig());
            builder.ApplyConfiguration(new UserLoginConfig());
            builder.ApplyConfiguration(new UserRoleConfig());
            builder.ApplyConfiguration(new UserTokenConfig());
            builder.ApplyConfiguration(new GenreConfig());
            builder.ApplyConfiguration(new AuthorConfig());
            builder.ApplyConfiguration(new BookConfig());
        }
    }
}
