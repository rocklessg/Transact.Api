namespace Transact.Application.DTOs.Responses;

public class AirtimeResponse
{
    public string TransactionReference { get; set; } = string.Empty;
    public string SourceAccount { get; set; } = string.Empty;
    public string NetworkProvider { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateTime TransactionDate { get; set; }
}
