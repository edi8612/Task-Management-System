using Microsoft.AspNetCore.Mvc;
using StudySync.Dtos;
using StudySync.Models;
using StudySync.Repositories;
using StudySync.Services;

namespace StudySync.Controllers;

[ApiController]
[Route("[controller]")]
public class CategoryController : ControllerBase
{
    private readonly ICategoryService _categoryService;

    public CategoryController(ICategoryService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<CategoryDTO>>> GetCategories()
    {
        var categories = await _categoryService.GetAllCategoriesAsync();
        return Ok(categories);
    }


    [HttpGet("{id}")]
    public async Task<ActionResult<CategoryDTO>> GetCategory(int id)
    {
        var category = await _categoryService.GetCategoryByIdAsync(id);
        if (category == null)
        {
            return NotFound();
        }
        return Ok(category);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CategoryCreateDTO createDTO)
    {
        var createdCategory = await _categoryService.CreateCategoryAsync(createDTO);
        return CreatedAtAction(
            nameof(GetCategory),
            new { id = createdCategory.Id },
            createdCategory);



    }









}