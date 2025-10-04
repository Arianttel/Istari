using Maiar.FluentValidator.Abstraction;
using Maiar.Resulting.Abstraction;

namespace Maiar.FluentValidator;
internal sealed class Validator<T> : IValidator<T>
{
	private readonly FluentValidation.IValidator<T> _validator;
	
	public Validator(FluentValidation.IValidator<T> validator)
	{
		_validator = validator;
	}

	public async Task<Result> ValidateAsync(T value, CancellationToken cancellationToken)
	{
		var result = await _validator.ValidateAsync(value, cancellationToken);
		var errors = result.Errors.Select(e => e.ErrorMessage);

		if (errors.Any())
		{
			return ResultFactory.Validation<T>(errors);
		}

		return ResultFactory.Ok();
	}
}
