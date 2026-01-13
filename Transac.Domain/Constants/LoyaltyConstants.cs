namespace Transac.Domain.Constants;

public static class LoyaltyConstants
{
    public const int BusinessPointsPerTransaction = 5;
    public const decimal BusinessMinTransactionAmount = 100000m;
    public const int BusinessPointsThresholdForCashback = 100;
    public const decimal BusinessCashbackAmount = 5000m;

    public const int RetailPointsPerTransaction = 2;
    public const decimal RetailMinTransactionAmount = 20000m;
    public const int RetailTransactionsForFreeAirtime = 10;
    public const decimal RetailFreeAirtimeAmount = 1000m;

    public const int TenureYearsForDoublePoints = 5;
    public const int MaxDoublePointsTransactionsPerMonth = 5;
}
