using System.ComponentModel.DataAnnotations;

namespace MyBlog.DTOs
{
    public class ResponseCategoryDTO
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Description { get; private set; }


        public ResponseCategoryDTO()
        {
            
        }
        public ResponseCategoryDTO(Guid id, string title, string description)
        {
            Id = id;
            Title = title;
            Description = description;
        }
    }
}
