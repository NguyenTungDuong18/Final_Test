namespace TestRepo.Service.User;

public interface IService
{
    public Task<string> CreateUser(Request.CreateUserRequest request);
}