using FluentValidation;
using StudyBudAPI.Entities;

namespace StudyBudAPI.Models.Validator
{
	public class CreateTopicDtoValidator : AbstractValidator<CreateTopicDto>
	{
        public CreateTopicDtoValidator(StudyBudDbContext dbContext)
        {
            RuleFor(x => x.Name)
                .NotEmpty()
				.Matches("^[a-zA-Z0-9\\s]+$").WithMessage("Name can only contain letters, numbers, and white spaces")
	            .Must(name => Char.IsLetterOrDigit(name[0])).WithMessage("Name must start with a letter or a digit");

			RuleFor(x => x.Name)
                .Custom((value, context) =>
                {
                    var nameInUse = dbContext.Topics.Any(t => t.Name == value);
                    if (nameInUse)
                    {
                        context.AddFailure(nameof(Topic.Name), "That topic is already created");
                    }
                });
        }
    }
}
