using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Entities.Dtos.AuthorDtos
{
    public class AuthorAddDto
    {
        [DisplayName("Yazar İsim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden fazla olamaz.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        public string Name { get; set; }

        [DisplayName("Yazar Soyisim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden fazla olamaz.")]
        [MinLength(2, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        public string Surname { get; set; }
    }
}
