namespace Maiar.Resulting.Abstraction;
public class Result
{
	public bool IsSuccess => Error is not null;
	public Error? Error { get; }

	public Result() { }
	public Result(Error error)
	{
		Error = error;
	}
}

public sealed class Result<T> : Result
{
	public T? Value { get; }

	public Result(T value)
	{
		Value = value;
	}

	public Result(Error error) : base(error) { }
}