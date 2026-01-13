namespace Transact.Application.DTOs.Requests;

public class TransferRequest
{
    public string SourceAccount { get; set; } = string.Empty;
    public string DestinationAccount { get; set; } = string.Empty;
    public decimal Amount { get; set; }
}
