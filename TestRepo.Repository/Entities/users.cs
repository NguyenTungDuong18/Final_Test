using TestRepo.Repository.Base;

namespace TestRepo.Repository.Entities;

public class users:BaseEntity<Guid>,IAuditable
{
    public string password { get; set; }
    public string email { get; set; }
    public string role { get; set; } 
    
    
    public sellers? sellers { get; set; }
    public Guid? sellersId { get; set; }
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdateAt { get; set; }
}