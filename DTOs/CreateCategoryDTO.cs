using System.ComponentModel.DataAnnotations;

namespace MyBlog.DTOs
{
    public class CreateCategoryDTO
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Só é permitido no máximo 100 caracteres")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(180, ErrorMessage = "Só é permitido no máximo 180 caracteres")]
        public string Description { get; set; }
    }
}
