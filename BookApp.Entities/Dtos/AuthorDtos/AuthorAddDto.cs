using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookApp.Entities.Dtos.AuthorDtos
{
    public class AuthorAddDto
    {
        [DisplayName("Yazar İsim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden fazla olamaz.")]
        [MinLength(1, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        public string Name { get; set; }

        [DisplayName("Yazar Soyisim")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(30, ErrorMessage = "{0} {1} karakterden fazla olamaz.")]
        [MinLength(1, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        public string Surname { get; set; }
    }
}
