using BookApp.Shared.Entities;
using System;

namespace BookApp.Entities
{
    public class Book : EntityBase, IEntity
    {
        public string Title { get; set; }
        public string ImageUrl { get; set; }
        public int GenreID { get; set; }
        public Genre Genre { get; set; }
        public int PageCount { get; set; }
        public DateTime PublishDate { get; set; }
        public int AuthorID { get; set; }
        public Author Author { get; set; }
    }
}
