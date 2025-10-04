using Maiar.Resulting.Abstraction.Errors;

namespace Maiar.Resulting.Abstraction;
public static class ResultFactory
{
	public static Result Ok() => new Result();
	public static Result<T> Ok<T>(T value) => new Result<T>(value);
	public static Result<T> NotFound<T>(string message) => new Result<T>(new NotFound(message));
	public static Result Validation(string message) => new Result(new Validation(message));
	public static Result<T> Validation<T>(string message) => new Result<T>(new Validation(message));
	public static Result Validation(IEnumerable<string> messages) => new Result(new Validation(messages));
	public static Result<T> Validation<T>(IEnumerable<string> messages) => new Result<T>(new Validation(messages));
}
