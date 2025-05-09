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
<<<<<<< HEAD
        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository,IMapper mapper)
=======
        public CategoryService(ICategoryRepository categoryRepository, IUserRepository userRepository, IMapper mapper)
>>>>>>> 2f844f17d9af319df8d5f522749a05fd978618a5
        {
            _categoryRepository = categoryRepository;
            _userRepository = userRepository;
            _mapper = mapper;
<<<<<<< HEAD
=======

>>>>>>> 2f844f17d9af319df8d5f522749a05fd978618a5
        }

        public async Task<CategoryDTO> CreateCategoryAsync(CategoryCreateDTO category)
        {
            
            var categoryEntity = _mapper.Map<Category>(category);
            if (string.IsNullOrWhiteSpace(categoryEntity.Name))
            {
                throw new ArgumentException("Category name cannot be empty.");
            }

            // Validate category name

            if (categoryEntity.Name.Length < 3)
            {
                throw new ArgumentException("Category name must be at least 3 characters long.");
            }

            if (categoryEntity.Name.Length > 50)
            {
                throw new ArgumentException("Category name must be less than 50 characters long.");
            }

            // Check if the user exists
            //var user = await _userRepository.GetUserByIdAsync(categoryEntity.UserId);

            await _categoryRepository.AddCategoryAsync(categoryEntity);

            return _mapper.Map<CategoryDTO>(categoryEntity);






        }

        public async Task DeleteCategoryAsync(int id)
        {
            await _categoryRepository.DeleteCategoryAsync(id);
        }

        public async Task<IEnumerable<CategoryDTO>> GetAllCategoriesAsync()
        {
<<<<<<< HEAD
            var categories =  await _categoryRepository.GetAllCategoriesAsync();
=======
            var categories = await _categoryRepository.GetAllCategoriesAsync();

>>>>>>> 2f844f17d9af319df8d5f522749a05fd978618a5
            return _mapper.Map<IEnumerable<CategoryDTO>>(categories);

        }

        public async Task<IEnumerable<CategoryDTO>> GetCategoriesWithMinTasksAsync(int mintask)
        {
         
            var category =  await _categoryRepository.GetCategoriesWithMinTasksAsync(mintask);
            return _mapper.Map<IEnumerable<CategoryDTO>>(category);


        }

        public async Task<CategoryDTO> GetCategoryByIdAsync(int id)
        {
            var category = await _categoryRepository.GetCategoryByIdAsync(id);
<<<<<<< HEAD
            if (category == null)
            {
                throw new KeyNotFoundException($"Category with ID {id} not found.");
            }
=======
>>>>>>> 2f844f17d9af319df8d5f522749a05fd978618a5
            return _mapper.Map<CategoryDTO>(category);
        }

        public async Task UpdateCategoryAsync(Category category)
        {
            await _categoryRepository.UpdateCategoryAsync(category);
        }
    }
}
