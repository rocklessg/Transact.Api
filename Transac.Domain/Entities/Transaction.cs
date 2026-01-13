using Transac.Domain.Enums;

namespace Transac.Domain.Entities;

public class Transaction
{
    public Guid Id { get; set; }
    public Guid SourceAccountId { get; set; }
    public Guid? DestinationAccountId { get; set; }
    public string SourceAccountNumber { get; set; } = string.Empty;
    public string? DestinationAccountNumber { get; set; }
    public decimal Amount { get; set; }
    public TransactionType TransactionType { get; set; }
    public string? NetworkProvider { get; set; }
    public string? PhoneNumber { get; set; }
    public string Reference { get; set; } = string.Empty;
    public string? Narration { get; set; }
    public DateTime TransactionDate { get; set; }
    public bool IsSuccessful { get; set; }
}
