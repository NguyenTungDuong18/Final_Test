using TestRepo.Repository.Base;

namespace TestRepo.Repository.Entities;

public class sellers:BaseEntity<Guid>,IAuditable
{
    public string tax_code { get; set; }
    public string company_name { get; set; }
    public string company_address { get; set; }
    
    public users users { get; set; }
    public Guid user_id { get; set; }
    
    public ICollection<products>? products { get; set; } = new List<products>();
    
    
    
    public DateTimeOffset CreatedAt { get; set; }
    public DateTimeOffset? UpdateAt { get; set; }
}