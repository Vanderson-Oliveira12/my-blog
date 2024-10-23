using System.ComponentModel.DataAnnotations;

namespace MyBlog.Models
{
    public class Category : Base
    {
       

        public string Title { get; private set; }
        public string Description { get; private set; }

        public Category()
        {
            
        }

        public Category(string title, string description)
        {
            Title = title;
            Description = description;
        }

        public void ChangeTitle(string title) { 
            Title = title;
        }

        public void ChangeDescription(string description) {
            Description = description;
        }

    }
}
