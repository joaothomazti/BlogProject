using Blog.Application.Dtos.Category;
using Blog.Application.Interfaces;
using Blog.Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Blog.Controllers
{
    [ApiController]
    [Route("v1/categories")]
    public class CategoriesController : ControllerBase
    {
        private readonly ICatergory _catergory;
        
        public CategoriesController(ICatergory catergory)
        {
            _catergory = catergory;
        }
        
        [HttpGet()]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var categories = await _catergory.GetAllAsync();
                return Ok(new ResultDto<List<Category>>(categories));
            }
            catch
            {
                return StatusCode(500, new ResultDto<List<Category>>("Internal server error."));
            }
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            try
            {
                
                var category = await _catergory.GetByIdAsync(id);
                
                if (category == null)
                    return NotFound(new ResultDto<Category>("Category not found."));
                
                return Ok(new ResultDto<Category>(category));
            }
            catch (Exception)
            {
                return StatusCode(500, new ResultDto<Category>("Internal server error."));
            }
        }
        
        [HttpPost()]
        public async Task<IActionResult> CreateAsync([FromBody]CategoryDto category)
        {
            try

            {
                var categoryModel = new Category
                {
                    Name = category.Name,
                    Slug = category.Slug.ToLower()
                };

                await _catergory.CreateAsync(categoryModel);

                return Created($"v1/categories/{categoryModel.Id}", new ResultDto<Category>(categoryModel));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultDto<Category>("Unable to add the category."));
            }
            catch
            {
                return StatusCode(500, new ResultDto<Category>("Internal server error."));
            }
            
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] int id, [FromBody] CategoryDto category)
        {
            try
            {
                var categoryEntity = new Category
                {
                    Name = category.Name,
                    Slug = category.Slug.ToLower()
                };

                var categoryModel = await _catergory.UpdateAsync(id, categoryEntity);

                if (categoryModel == null)
                    return NotFound(new ResultDto<Category>("Category not found."));

                return Ok(new ResultDto<Category>(categoryModel));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultDto<Category>("Unable to update the category."));
            }catch
            {
                return StatusCode(500, new ResultDto<Category>("Internal server error."));
            }
        }
        
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> DeleteAsync([FromRoute]int id)
        {
            try
            {
                var category = await _catergory.DeleteAsync(id);

                if (!category)
                    return NotFound(new ResultDto<Category>("Category not found."));

                return Ok(new ResultDto<Category>("Category deleted."));
            }
            catch (DbUpdateException)
            {
                return StatusCode(500, new ResultDto<Category>("Unable to delete the category."));
            }
            catch
            {
                return StatusCode(500, new ResultDto<Category>("Internal server error."));
            }
        }
    }
}
