namespace TestRepo.Service.User;

public class Request
{
    public class CreateUserRequest
    {
        public string email { get; set; }
        public string password { get; set; }
    }
}