using Microsoft.AspNetCore.Mvc;
using TestRepo.Service.Category;

namespace TestRepo.Api.Controller;

[ApiController]
[Route("[controller]")]
public class CategoryController:ControllerBase
{
    private readonly IService _categoryService;
    public CategoryController(IService categoryService)
    {
        _categoryService = categoryService;
    }

    [HttpPost("CreateCategory")]
    public async Task<IActionResult> CreateCategory([FromForm]Request.CreateCategoryRequest request)
    {
        var result = await _categoryService.CreateCategory(request);
        return Ok(result);
    }

    [HttpGet("GetAllCategories")]
    public async Task<IActionResult> GetAllCategories(string? searchTerm)
    {
        var result = await _categoryService.GetAllCategories(searchTerm);
        return Ok(result);
    }

    [HttpGet("GetAllChildCategories")]
    public async Task<IActionResult> GetAllChildCategories(Guid parentId)
    {
        var result = await _categoryService.GetAllChildCategories(parentId);
        return Ok(result);
    }
}