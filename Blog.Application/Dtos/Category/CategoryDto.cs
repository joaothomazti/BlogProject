using System.ComponentModel.DataAnnotations;

namespace Blog.Application.Dtos.Category
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Slug { get; set; }
    }
}
