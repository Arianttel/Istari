using System.Collections.Immutable;

namespace Maiar.Resulting.Abstraction;
public abstract class Error
{
	protected IImmutableList<string> _messages;

	public Error(IEnumerable<string> messages)
	{
		_messages = messages.ToImmutableArray();
	}
}