using AutoMapper;
using StudySync.Dtos;
using StudySync.Models;
using StudySync.Repositories;

namespace StudySync.Services
{
    public class CategoryService : ICategoryService
    {

        private readonly ICategoryRepository _categoryRepository;
        private readonly IUserRepository _userRepository; // Assuming you have a user repository
        private readonly IMapper _mapper;
        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository, IMapper mapper)
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task CreateCategoryAsync(Category category)
        {
            await _categoryRepository.AddCategoryAsync(category);
           
        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
            var categories = await _categoryRepository.GetAllCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);

        }

        public async Task<IEnumerable<Category>> GetCategoriesWithMinTasksAsync(int mintask)
        {
         
            return await _categoryRepository.GetCategoriesWithMinTasksAsync(mintask);

        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
