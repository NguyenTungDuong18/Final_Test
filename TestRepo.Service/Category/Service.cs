using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;
using TestRepo.Repository.Entities;

namespace TestRepo.Service.Category;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateCategory(Request.CreateCategoryRequest request)
    {
        if (request.parentId != null)
        {
            var parent = await _dbContext.categories.Where(x => x.Id == request.parentId).FirstOrDefaultAsync();
            if (parent == null)
            {
                throw new Exception("parent not found");
            }
        }

        var cate = await _dbContext.categories.Where(x => x.name == request.name).AnyAsync();
        if (cate)
        {
            throw new Exception("cate already exists");
        }

        var newCate = new category()
        {
            name = request.name,
            parent_id = request.parentId,
        };

        _dbContext.categories.Add(newCate);
        var check = await _dbContext.SaveChangesAsync();
        if (check > 0)
        {
            return "success";
        }

        return "fail";
    }

    public  async Task<List<Response.GetAllCategory>> GetAllCategories(string? searchTerm)
    {
        var query = _dbContext.categories.Where(x => true);
        if (searchTerm != null)
        {
            query = query.Where(x => x.name.Contains(searchTerm));
        }
        
        query = query.OrderBy(x => x.name);

        var selectedQuery = query.Select(x => new Response.GetAllCategory()
        {
            name = x.name,
            id = x.Id,
        });
        
        var result =  await selectedQuery.ToListAsync();
        return result;
    }

    public async Task<List<Response.GetAllCategory>> GetAllChildCategories(Guid parentId)
    {
        var parent = await _dbContext.categories.Where(x => x.Id == parentId).AnyAsync();
        if (!parent)
        {
            throw new Exception("parent not found");
        }
        
        var query = _dbContext.categories.Where(x => x.parent_id == parentId);
        query = query.OrderBy(x => x.name);

        var selected = query.Select(x => new Response.GetAllCategory()
        {
            name = x.name,
            id = x.Id,
        });
        
        var result =  await selected.ToListAsync();
        return result;
    }
}