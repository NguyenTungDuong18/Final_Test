using TestRepo.Repository.Base;

namespace TestRepo.Repository.Entities;

public class category:BaseEntity<Guid>,IAuditable
{
    public string name { get; set; }
    
    public category? Parent { get; set; }
    public Guid? parent_id { get; set; }
    
    public ICollection<category>? children { get; set; } = new List<category>();
    
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdateAt { get; set; }
}