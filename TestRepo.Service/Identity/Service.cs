using System.Security.Claims;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestRepo.Repository;
using TestRepo.Service.JwtService;

namespace TestRepo.Service.Identity;

public class Service : IService
{
    private readonly AppDbContext _dbContext;
    private readonly JwtService.IService _jwtService;
    private readonly JwtOptions  _jwtOptions = new();

    public Service(AppDbContext dbContext, JwtService.IService jwtService,IConfiguration configuration)
    {
        _dbContext = dbContext;
        _jwtService = jwtService;
        configuration.GetSection(nameof(JwtOptions)).Bind(_jwtOptions);
    }

    public async Task<Response.IdentityResponse> Login(string email, string password)
    {
        var user = await _dbContext.users.Where(x => x.email == email).FirstOrDefaultAsync();
        if (user == null)
        {
            throw new Exception("user  not found");
        }

        if (user.password != password)
        {
            throw new Exception("invalid password");
        }

        var claims = new List<Claim>()
        {
            new Claim("Email", user.email),
            new Claim("Password", user.password),
            new Claim("Role", user.role),
            new Claim(ClaimTypes.Role, user.role),
            new Claim(ClaimTypes.Expired, DateTimeOffset.UtcNow.AddMinutes(_jwtOptions.ExpireMinutes).ToString())

        };
        
        var token = _jwtService.GenerateAccessToken(claims);
        var result = new Response.IdentityResponse()
        {
            access_token = token,
        };
        
        return result;
    }
}