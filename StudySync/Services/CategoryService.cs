using StudySync.Models;
using StudySync.Repositories;

namespace StudySync.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository; // Assuming you have a user repository
        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
           
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<IEnumerable<Category>> GetAllCategoriesAsync()
        {
            return await _categoryRepository.GetAllCategoriesAsync();

        }

        public async Task<IEnumerable<Category>> GetCategoriesWithMinTasksAsync(int mintask)
        {
         
            return await _categoryRepository.GetCategoriesWithMinTasksAsync(mintask);

        }

        public async Task<Category> GetCategoryByIdAsync(int id)
        {
            return  await _categoryRepository.GetCategoryByIdAsync(id);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
