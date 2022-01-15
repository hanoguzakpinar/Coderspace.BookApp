using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookApp.Shared.Entities;

namespace BookApp.Entities
{
    public class Author : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> Books { get; set; }
    }
}
