using Transact.Application.DTOs.Requests;

namespace Transact.Application.Validators;

public interface IValidator<T>
{
    (bool IsValid, List<string> Errors) Validate(T request);
}

public class TransferRequestValidator : IValidator<TransferRequest>
{
    public (bool IsValid, List<string> Errors) Validate(TransferRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.SourceAccount))
            errors.Add("Source account is required");

        if (string.IsNullOrWhiteSpace(request.DestinationAccount))
            errors.Add("Destination account is required");

        if (request.Amount <= 0)
            errors.Add("Amount must be greater than zero");

        if (request.SourceAccount == request.DestinationAccount)
            errors.Add("Source and destination accounts cannot be the same");

        return (errors.Count == 0, errors);
    }
}

public class BuyAirtimeRequestValidator : IValidator<BuyAirtimeRequest>
{
    private static readonly HashSet<string> ValidProviders = new(StringComparer.OrdinalIgnoreCase)
    {
        "MTN", "Glo", "Airtel", "9Mobile", "NineMobile"
    };

    public (bool IsValid, List<string> Errors) Validate(BuyAirtimeRequest request)
    {
        var errors = new List<string>();

        if (string.IsNullOrWhiteSpace(request.SourceAccount))
            errors.Add("Source account is required");

        if (string.IsNullOrWhiteSpace(request.NetworkProvider))
            errors.Add("Network provider is required");
        else if (!ValidProviders.Contains(request.NetworkProvider))
            errors.Add("Invalid network provider. Valid options: MTN, Glo, Airtel, 9Mobile");

        if (request.Amount <= 0)
            errors.Add("Amount must be greater than zero");

        if (string.IsNullOrWhiteSpace(request.PhoneNumber))
            errors.Add("Phone number is required");
        else if (request.PhoneNumber.Length < 10 || request.PhoneNumber.Length > 14)
            errors.Add("Invalid phone number format");

        return (errors.Count == 0, errors);
    }
}
