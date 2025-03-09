using Blog.Application.Interfaces;
using Blog.Domain.Models;
using Blog.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Blog.Infrastructure.Repository
{
    public class CategoriesRepository : ICatergory
    {
        private readonly BlogDbContext _dbContext;

        public CategoriesRepository(BlogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<Category>> GetAllAsync()
        {
            return await _dbContext.Categories.AsNoTracking().ToListAsync();
        }

        public async Task<Category?> GetByIdAsync(int id)
        {
            return await _dbContext.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<Category> CreateAsync(Category category)
        {
            await _dbContext.Categories.AddAsync(category);
            await _dbContext.SaveChangesAsync();
            return category;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var category = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            
            if (category == null)
                return false;
            
            _dbContext.Categories.Remove(category);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<Category?> UpdateAsync(int id,Category category)
        {
            var existingCategory = await _dbContext.Categories.FirstOrDefaultAsync(x => x.Id == id);
            if(existingCategory == null)
                return null;
            
            existingCategory.Name = category.Name;
            existingCategory.Slug = category.Slug;
                
            await _dbContext.SaveChangesAsync();
            return existingCategory;
        }
        
    }
}
