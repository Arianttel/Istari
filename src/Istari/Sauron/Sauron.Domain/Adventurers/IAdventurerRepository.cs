namespace Sauron.Domain.Adventurers;
public interface IAdventurerRepository
{
	Task<Adventurer> CreateAsync(Adventurer adventurer, CancellationToken cancellationToken);
	Task<Adventurer> GetAsync(Adventurer adventurer, CancellationToken cancellationToken);
}
