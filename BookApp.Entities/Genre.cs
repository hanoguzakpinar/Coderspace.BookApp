using BookApp.Shared.Entities;
using System.Collections.Generic;

namespace BookApp.Entities
{
    public class Genre : EntityBase, IEntity
    {
        public string Name { get; set; }
        public List<Book> Books { get; set; }
    }
}
