using StudySync.Models;

namespace StudySync.Services
{
    public interface ICategoryService
    {
        public Task<IEnumerable<Category>> GetAllCategoriesAsync();
        public Task<Category?> GetCategoryByIdAsync(int id);

        public Task CreateCategoryAsync(Category category);

        public Task UpdateCategoryAsync(Category category);

        public Task DeleteCategoryAsync(int id);

        public Task<IEnumerable<Category>> GetCategoriesWithMinTasksAsync(int minTask);




    }
}
