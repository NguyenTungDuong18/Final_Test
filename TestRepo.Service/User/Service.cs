using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;
using TestRepo.Repository.Entities;

namespace TestRepo.Service.User;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateUser(Request.CreateUserRequest request)
    {
        var checkEmail = await _dbContext.users.Where(x => x.email == request.email).AnyAsync();
        if (checkEmail)
        {
            throw new Exception("user already exists");
        }

        var newUSer = new users()
        {
            email = request.email,
            password = request.password,
            role = "User"
        };
        _dbContext.Add(newUSer);
        var check = await _dbContext.SaveChangesAsync();
        if (check > 0)
        {
            return "success";
        }

        return "fail";
    }
}