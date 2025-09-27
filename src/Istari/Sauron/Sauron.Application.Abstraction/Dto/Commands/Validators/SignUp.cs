using FluentValidation;

namespace Sauron.Application.Abstraction.Dto.Commands.Validators;
public sealed class SignUp : AbstractValidator<Commands.SignUp>
{
	public SignUp()
	{
		RuleFor(x => x.Password).NotEmpty();
		RuleFor(x => x.Password).Equal(x => x.RepeatPassword);
		RuleFor(x => x.Password)
			.MinimumLength(Constants.Password.MinLength)
			.MaximumLength(Constants.Password.MaxLength);

		RuleFor(x => x.RepeatPassword).NotEmpty();
		RuleFor(x => x.RepeatPassword).Equal(x => x.Password);
		RuleFor(x => x.RepeatPassword)
			.MinimumLength(Constants.Password.MinLength)
			.MaximumLength(Constants.Password.MaxLength);

		RuleFor(x => x.Name).NotEmpty();
		RuleFor(x => x.Name)
			.MinimumLength(Constants.Name.MinLength)
			.MaximumLength(Constants.Name.MaxLength);
	}
}
