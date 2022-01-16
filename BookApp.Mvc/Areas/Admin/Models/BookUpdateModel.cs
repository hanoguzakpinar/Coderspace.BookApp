using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using BookApp.Entities;

namespace BookApp.Mvc.Areas.Admin.Models
{
    public class BookUpdateModel
    {
        public IList<Genre> Genres { get; set; }
        public IList<Author> Authors { get; set; }

        [Required]
        public int Id { get; set; }

        [DisplayName("Kitap İsmi")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(100, ErrorMessage = "{0} {1} karakterden fazla olamaz.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        public string Title { get; set; }

        [DisplayName("Yayın Tarihi")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PublishDate { get; set; }

        [DisplayName("Sayfa Sayısı")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        [Range(10, int.MaxValue, ErrorMessage = "{0} {1}'dan büyük olmalıdır.")]
        public int PageCount { get; set; }

        [DisplayName("Kapak Resmi")]
        [MaxLength(200, ErrorMessage = "{0} {1} karakterden fazla olamaz.")]
        [MinLength(7, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        public string ImageUrl { get; set; }

        [DisplayName("Tür")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int GenreId { get; set; }

        [DisplayName("Yazar")]
        [Required(ErrorMessage = "{0} alanı boş geçilmemelidir.")]
        public int AuthorId { get; set; }
    }
}
