using Maiar.FluentValidator.Abstraction;
using Maiar.Resulting.Abstraction;

namespace Maiar.FluentValidator;
internal sealed class Validator<T> : IValidator<T>
{
	private readonly FluentValidation.IValidator<T> _validator;
	private readonly IResolver _resolver;
	
	public Validator(
		FluentValidation.IValidator<T> validator,
		IResolver resolver)
	{
		_validator = validator;
		_resolver = resolver;
	}

	public async Task<Result> ValidateAsync(T value, CancellationToken cancellationToken)
	{
		var result = await _validator.ValidateAsync(value, cancellationToken);
		var errors = result.Errors.Select(e => e.ErrorMessage);

		if (errors.Any())
		{
			return _resolver.Validation<T>(errors);
		}

		return _resolver.Empty();
	}
}
