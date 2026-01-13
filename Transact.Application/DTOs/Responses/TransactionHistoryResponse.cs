namespace Transact.Application.DTOs.Responses;

public class TransactionHistoryResponse
{
    public string AccountNumber { get; set; } = string.Empty;
    public List<TransactionDetail> Transactions { get; set; } = new();
}

public class TransactionDetail
{
    public string TransactionReference { get; set; } = string.Empty;
    public string TransactionType { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string? DestinationAccount { get; set; }
    public string? NetworkProvider { get; set; }
    public string? PhoneNumber { get; set; }
    public string? Narration { get; set; }
    public DateTime TransactionDate { get; set; }
    public bool IsSuccessful { get; set; }
}
