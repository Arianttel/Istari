namespace Sauron.Domain.Adventurers;
public sealed class Adventurer
{
	public required string Name { get; init; }
	public required byte[] Password { get; init; }
}
