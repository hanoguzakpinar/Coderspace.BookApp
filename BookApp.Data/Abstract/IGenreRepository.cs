using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Entities;

namespace BookApp.Data.Abstract
{
    public interface IGenreRepository : IEntityRepository<Genre>
    {
    }
}
