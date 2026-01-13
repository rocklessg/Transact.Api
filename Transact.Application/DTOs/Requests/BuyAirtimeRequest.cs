namespace Transact.Application.DTOs.Requests;

public class BuyAirtimeRequest
{
    public string SourceAccount { get; set; } = string.Empty;
    public string NetworkProvider { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public string PhoneNumber { get; set; } = string.Empty;
}
