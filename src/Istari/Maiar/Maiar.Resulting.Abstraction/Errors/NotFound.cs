
namespace Maiar.Resulting.Abstraction.Errors;
public sealed class NotFound : Error
{
	public NotFound(string message) : base([message]) { }
}
