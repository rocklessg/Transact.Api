using Transac.Domain.Enums;

namespace Transac.Domain.Entities;

public class Customer
{
    public Guid Id { get; set; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public CustomerType CustomerType { get; set; }
    public DateTime DateCreated { get; set; }
    public DateTime? DateModified { get; set; }
    public bool IsActive { get; set; }

    public int GetTenureInYears()
    {
        return (DateTime.UtcNow - DateCreated).Days / 365;
    }
}
