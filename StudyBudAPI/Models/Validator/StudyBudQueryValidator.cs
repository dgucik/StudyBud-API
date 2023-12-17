using FluentValidation;

namespace StudyBudAPI.Models.Validator
{
	public class StudyBudQueryValidator : AbstractValidator<StudyBudQuery>
	{
		private int[] allowedPageSize = { 5, 10, 15 };

		public StudyBudQueryValidator()
		{
			RuleFor(r => r.PageNumber)
				.GreaterThanOrEqualTo(1);

			RuleFor(r => r.PageSize)
				.Custom((value, context) =>
				{
					if (!allowedPageSize.Contains(value))
					{
						context.AddFailure(nameof(StudyBudQuery.PageSize), $"Page size must be in [{string.Join(", ", allowedPageSize)}]");
					}
				});
		}
	}
}
