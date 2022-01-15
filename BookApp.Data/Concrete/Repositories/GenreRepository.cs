using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Data.Abstract;
using BookApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookApp.Data.Concrete.Repositories
{
    public class GenreRepository : EntityRepository<Genre>,IGenreRepository
    {
        public GenreRepository(DbContext context) : base(context)
        {
        }
    }
}
