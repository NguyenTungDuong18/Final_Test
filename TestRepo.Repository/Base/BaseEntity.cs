namespace TestRepo.Repository.Base;

public class BaseEntity <Tkey>
{
    public Tkey Id { get; set; }
    public bool IsDeleted { get; set; }
}