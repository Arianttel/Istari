using Maiar.Resulting.Abstraction;

namespace Maiar.FluentValidator.Abstraction;
public interface IValidator<in T>
{
	Task<Result> ValidateAsync(T value, CancellationToken cancellationToken);
}
