namespace Sauron.Domain.ValueObjects;
public sealed class Password
{
	public byte[] Hash { get; }

	private Password() { }
}
