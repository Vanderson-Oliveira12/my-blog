using System.ComponentModel.DataAnnotations;

namespace MyBlog.DTOs
{
    public class RequestCategoryDTO
    {

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Só é permitido no máximo 100 caracteres")]
        [MinLength(5, ErrorMessage = "O título deve ter no mínimo 5 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MinLength(5, ErrorMessage = "A descrição deve ter no mínimo 5 caracteres")]
        [MaxLength(180, ErrorMessage = "Só é permitido no máximo 180 caracteres")]
        public string Description { get; set; }
    }
}
