using Microsoft.EntityFrameworkCore;
using TestRepo.Repository;
using TestRepo.Repository.Entities;

namespace TestRepo.Service.Seller;

public class Service : IService
{
    private readonly AppDbContext _dbContext;

    public Service(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<string> CreateSeller(Request.CreateSellerRequest request)
    {
        var User = await _dbContext.users.Where(x => x.email == request.email).FirstOrDefaultAsync();
        if (User != null)
        {
            throw new Exception("User already exists");
        }

        var seller = await _dbContext.sellers.Where(x => x.user_id == User.Id).FirstOrDefaultAsync();
        if (seller != null)
        {
            throw new Exception("Seller already exists");
        }

        var newUSer = new users()
        {
            email = request.email,
            password = request.password,
        };
        _dbContext.Add(newUSer);
        var checkuser = await _dbContext.SaveChangesAsync();
        if (checkuser > 0)
        {
            var newSeller = new sellers()
            {
                tax_code = request.tax_code,
                company_address = request.company_address,
                company_name = request.company_name,
            };
            _dbContext.Add(newSeller);
            var check = await _dbContext.SaveChangesAsync();
            if (check > 0)
            {
                return "success";
            }
        }

        return "fail";
    }
}