using Maiar.Resulting.Abstraction;

namespace Sauron.Domain.ValueObjects;
public sealed class Password
{
	public byte[] Hash { get; }

	public Result Create(string password)
	{

	}
}
