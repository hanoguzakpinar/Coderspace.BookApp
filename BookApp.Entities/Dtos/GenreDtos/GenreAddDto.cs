using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace BookApp.Entities.Dtos.GenreDtos
{
    public class GenreAddDto
    {
        [DisplayName("Tür İsmi")]
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz.")]
        [MaxLength(50, ErrorMessage = "{0} {1} karakterden fazla olamaz.")]
        [MinLength(3, ErrorMessage = "{0} {1} karakterden az olamaz.")]
        public string Name { get; set; }
    }
}
