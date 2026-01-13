namespace Transac.Domain.Entities;

public class LoyaltyPoint
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid TransactionId { get; set; }
    public int Points { get; set; }
    public DateTime EarnedDate { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
}
