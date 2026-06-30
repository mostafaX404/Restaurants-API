
namespace Resturants.Infrastructure.Authorization;

    public static class PolicyNames
    {
    public const string HasNationality = "HasNationality";
    public const string AtLeast20 = "HasDateOfBirth";
    public const string CreatedAtLeast2Resturants = "CreatedAtLeast2Resturants";

    }


public static class AppClaimTypes
{
    public const string Nationality = "Nationality";
    public const string DateOfBirth = "DateOfBirth";
}