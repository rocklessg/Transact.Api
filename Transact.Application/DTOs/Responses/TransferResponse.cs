namespace Transact.Application.DTOs.Responses;

public class TransferResponse
{
    public string TransactionReference { get; set; } = string.Empty;
    public string SourceAccount { get; set; } = string.Empty;
    public string DestinationAccount { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
    public int PointsEarned { get; set; }
    public RewardInfo? Reward { get; set; }
}

public class RewardInfo
{
    public string RewardType { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string Message { get; set; } = string.Empty;
}
