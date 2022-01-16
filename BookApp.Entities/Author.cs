using BookApp.Shared.Entities;
using System.Collections.Generic;

namespace BookApp.Entities
{
    public class Author : EntityBase, IEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<Book> Books { get; set; }
    }
}
