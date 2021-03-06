using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Entities.Dtos.BookDtos
{
    public class BookAddDto
    {
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
