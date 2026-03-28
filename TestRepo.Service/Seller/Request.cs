namespace TestRepo.Service.Seller;

public class Request
{
    public class CreateSellerRequest: User.Request.CreateUserRequest
    {
        public string tax_code { get; set; }
        public string company_name { get; set; }
        public string company_address { get; set; }
    }
}