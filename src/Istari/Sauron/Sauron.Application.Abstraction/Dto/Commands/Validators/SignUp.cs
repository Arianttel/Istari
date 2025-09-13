using FluentValidation;

namespace Sauron.Application.Abstraction.Dto.Commands.Validators;
public sealed class SignUp : AbstractValidator<Commands.SignUp>
{
	public SignUp()
	{
		RuleFor(x => x.Password)
			.Equal(x => x.RepeatPassword);
	}
}
