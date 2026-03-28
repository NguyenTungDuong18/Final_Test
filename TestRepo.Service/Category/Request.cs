namespace TestRepo.Service.Category;

public class Request
{
    public class CreateCategoryRequest
    {
        public string name { get; set; }
        public Guid? parentId { get; set; }
    }
}