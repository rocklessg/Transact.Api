using Transac.Domain.Enums;

namespace Transac.Domain.Entities;

public class Reward
{
    public Guid Id { get; set; }
    public Guid CustomerId { get; set; }
    public Guid? TransactionId { get; set; }
    public RewardType RewardType { get; set; }
    public decimal Amount { get; set; }
    public DateTime AwardedDate { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public bool IsProcessed { get; set; }
}
