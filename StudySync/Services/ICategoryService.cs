using StudySync.Dtos;
using StudySync.Models;

namespace StudySync.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync();
        public Task<CategoryDTO?> GetCategoryByIdAsync(int id);

        public Task CreateCategoryAsync(CategoryCreateDTO category);

        public Task UpdateCategoryAsync(Category category);

        public Task DeleteCategoryAsync(int id);

        public Task<IEnumerable<CategoryDTO>> GetCategoriesWithMinTasksAsync(int minTask);




    }
}
