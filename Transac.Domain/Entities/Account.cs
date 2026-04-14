namespace Transac.Domain.Entities;

public class Account
{
    public int AccountId { get; set; }
    public string AccountNumber { get; set; } = string.Empty;
    public long CustomerId { get; set; }
    public decimal AccountBalance { get; set; }
    public DateTime AccountOpenDate { get; set; }
}
