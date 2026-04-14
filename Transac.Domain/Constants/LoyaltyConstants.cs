namespace Transac.Domain.Constants;

public static class LoyaltyConstants
{
    public const int BusinessPointsPerTransaction = 3;
    public const decimal BusinessMinTransactionAmount = 120000m;
    public const int BusinessPointsThresholdForCashback = 90;
    public const decimal BusinessCashbackAmount = 7500m;

    public const int RetailPointsPerTransaction = 2;
    public const decimal RetailMinTransactionAmount = 25000m;
    public const int RetailTransactionsForFreeAirtime = 7;
    public const decimal RetailFreeAirtimeAmount = 1500m;

    public const int TenureYearsForDoublePoints = 4;
    public const int MaxDoublePointsTransactionsPerMonth = 4;
}
