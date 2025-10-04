
namespace Maiar.Resulting.Abstraction.Errors;
public sealed class Validation : Error
{
	public Validation(string message) : base([message]) { }
	public Validation(IEnumerable<string> messages) : base(messages) { }
}
