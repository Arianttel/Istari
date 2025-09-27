namespace Maiar.Resulting.Abstraction;
public interface IResolver
{
	Result Empty();
	Result<T> WithValue<T>(T value);
	Result<T> NotFound<T>(string entityName);
	Result<T> Validation<T>(string message);
	Result<T> Validation<T>(IEnumerable<string> errors);
}
