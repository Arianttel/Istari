namespace Maiar.Resulting.Abstraction.Errors;
public sealed class Validation : Error
{
	public IReadOnlyCollection<string> Errors { get; }

	public Validation(string message, IEnumerable<string> errors) : base(message) 
	{
		Errors = errors.ToList();
	}
}
