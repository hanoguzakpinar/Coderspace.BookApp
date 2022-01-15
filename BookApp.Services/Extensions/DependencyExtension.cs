using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Data.Abstract;
using BookApp.Data.Concrete;
using BookApp.Data.Concrete.Contexts;
using BookApp.Services.Abstract;
using BookApp.Services.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BookApp.Services.Extensions
{
    public static class DependencyExtension
    {
        public static void AddDependencies(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<BookContext>(opt =>
            {
                opt.UseSqlServer(configuration.GetConnectionString("Local"));
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IAuthorService, AuthorManager>();
            services.AddScoped<IGenreService, GenreManager>();
            services.AddScoped<IBookService, BookManager>();
        }
    }
}
