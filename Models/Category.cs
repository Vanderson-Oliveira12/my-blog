using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Category : Base
    {
        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(100, ErrorMessage = "Só é permitido no máximo 100 caracteres")]
        public string Title { get; private set; }

        [Required(ErrorMessage = "Campo obrigatório")]
        [MaxLength(180, ErrorMessage = "Só é permitido no máximo 180 caracteres")]
        public string Description { get; private set; }
    }
}
