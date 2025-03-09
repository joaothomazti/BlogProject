using Blog.Domain.Models;

namespace Blog.Application.Interfaces
{
    public interface ICatergory
    {
        Task<List<Category>> GetAllAsync();
        Task<Category?> GetByIdAsync(int id);
        Task<Category> CreateAsync(Category category);
        Task<bool>  DeleteAsync(int id);
        Task<Category?> UpdateAsync(int id,Category category);
    }
}
