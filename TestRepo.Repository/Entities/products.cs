using TestRepo.Repository.Base;

namespace TestRepo.Repository.Entities;

public class products:BaseEntity<Guid>,IAuditable
{
    public string name { get; set; }
    
    public decimal price { get; set; }
    
    public sellers? sellers { get; set; }
    
    public Guid? userId { get; set; }
    
    
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdateAt { get; set; }
}