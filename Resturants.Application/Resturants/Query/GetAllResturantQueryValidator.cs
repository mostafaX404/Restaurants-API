
using FluentValidation;

namespace Resturants.Application.Resturants.Query;

public class GetAllRestaurantsQueryValidator : AbstractValidator<GetAllResturentesQuery>
{
    private int[] allowPageSizes = [5, 10, 15, 30];
    private string[] allowedSortByColumnNames = [
        nameof(ResturantDto.Name),
        nameof(ResturantDto.Category),
        nameof(ResturantDto.Description)

        ];

    public GetAllRestaurantsQueryValidator()
    {
        RuleFor(r => r.PageNumber)
            .GreaterThanOrEqualTo(1);

        RuleFor(r => r.PageSize)
            .Must(value => allowPageSizes.Contains(value))
            .WithMessage($"Page size must be in [{string.Join(",", allowPageSizes)}]");


        RuleFor(r => r.SortBy)
            .Must(value => allowedSortByColumnNames.Contains(value))
            .When(q=>q.SortBy != null)
            .WithMessage($"Page size must be in [{string.Join(",", allowedSortByColumnNames)}]");
    }
}