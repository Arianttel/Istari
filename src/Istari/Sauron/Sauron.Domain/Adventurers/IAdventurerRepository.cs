using Maiar.Resulting.Abstraction;

namespace Sauron.Domain.Adventurers;
public interface IAdventurerRepository
{
	Task<Result<Adventurer>> CreateAsync(Adventurer adventurer, CancellationToken cancellationToken);
	Task<Result<Adventurer>> GetAsync(Adventurer adventurer, CancellationToken cancellationToken);
}
