using System.ComponentModel.DataAnnotations;

namespace MyBlog.ViewModels;
public record UpdateCategoryViewModel
{
    //Sempre que nao tiver metodos, usar record
    [Required]
    [MaxLength(100)]
    [MinLength(5)]
    public string Title { get; set; }

    [Required]
    [MinLength(5)]
    [MaxLength(180)]
    public string Description { get; set; }
}
