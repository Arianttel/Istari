using Maiar.Resulting.Abstraction;
using Maiar.Resulting.Abstraction.Errors;
using Maiar.Resulting.Abstraction.Resources;
using Microsoft.Extensions.Localization;

namespace Maiar.Resulting;
internal sealed class Resolver : IResolver
{
	private readonly IStringLocalizer<Localization> _localizer;

	public Resolver(IStringLocalizer<Localization> localizer)
	{
		_localizer = localizer;
	}

	public Result Empty()
	{
		return new Result();
	}

	public Result<T> WithValue<T>(T value)
	{
		return new Result<T>(value);
	}

	public Result<T> NotFound<T>(string entityName)
	{
		return new Result<T>(new NotFound(_localizer[nameof(NotFound), entityName]));
	}

	public Result<T> Validation<T>(string error)
	{
		return new Result<T>(new Validation(_localizer[nameof(NotFound)], [error]));
	}

	public Result<T> Validation<T>(IEnumerable<string> errors)
	{
		return new Result<T>(new Validation(_localizer[nameof(NotFound)], errors));
	}
}
