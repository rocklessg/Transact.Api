using Transac.Domain.Enums;

namespace Transac.Domain.Entities;

public class Customer
{
    public long CustomerId { get; set; }
    public string CustomerName { get; set; } = string.Empty;
    public CustomerType CustomerType { get; set; }
    public DateTime DateCreated { get; set; }

    public int GetTenureInYears()
    {
        return (DateTime.UtcNow - DateCreated).Days / 365;
    }
}
