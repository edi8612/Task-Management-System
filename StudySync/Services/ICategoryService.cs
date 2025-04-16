using StudySync.Dtos;
using StudySync.Models;

namespace StudySync.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        public Task<CategoryDTO?> GetCategoryByIdAsync(int id);

        public Task CreateCategoryAsync(Category category);

        public Task UpdateCategoryAsync(Category category);

        public Task DeleteCategoryAsync(int id);

        public Task<IEnumerable<Category>> GetCategoriesWithMinTasksAsync(int minTask);




    }
}
