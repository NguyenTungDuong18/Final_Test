namespace TestRepo.Service.Category;

public interface IService
{
    public Task<string> CreateCategory(Request.CreateCategoryRequest request);
    
    public Task<List<Response.GetAllCategory>> GetAllCategories(string? searchTerm);
    
    public Task<List<Response.GetAllCategory>> GetAllChildCategories(Guid parentId);
}