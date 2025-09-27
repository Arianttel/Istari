namespace Maiar.Resulting.Abstraction;
public class Result
{
	public bool IsSuccess => Error is null;
	public Error? Error { get; }

	public Result() { }

	public Result(Error error)
	{
		Error = error;
	}
}

public sealed class Result<T> : Result
{
	private T? _value;

	public T Value 
	{ 
		get
		{
			if (_value is null)
			{
				throw new ArgumentNullException(nameof(_value), "Result is not initialized.");
			}

			return _value;
		}
	}

	public Result(T value)
	{
		_value = value;
	}

	public Result(Error error) : base(error) { }

	public static Result<T> FromError(Result result)
	{
		if (result.IsSuccess)
		{
			throw new ArgumentException("Cannot create error result from success result.", nameof(result));
		}

		return new Result<T>(result.Error!);
	}
}
