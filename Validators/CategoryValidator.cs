using FluentValidation;
using MyBlog.DTOs;

namespace MyBlog.Validations
{
    public class CategoryValidator : AbstractValidator<RequestCategoryDTO>
    {
        public CategoryValidator() {

            RuleFor(x => x.Title)
                .MinimumLength(5)
                .WithMessage("Só é permitido no míninimo 5 caracteres")
                .MaximumLength(100)
                .WithMessage("Só é permitido no máximo 180 caracteres");

            RuleFor(x => x.Description)
                .MinimumLength(5)
                .WithMessage("Só é permitido no míninimo 5 caracteres")
                .MaximumLength(180)
                .WithMessage("Só é permitido no máximo 180 caracteres");
                
        }
    }
}
