using Sauron.Application.Abstraction.Dto;
using Sauron.Domain.Adventurers;

namespace Sauron.Application;
internal sealed class SignUpService
{
	private readonly IAdventurerRepository _adventurerRepository;

	public SignUpService(IAdventurerRepository adventurerRepository)
	{
		_adventurerRepository = adventurerRepository;
	}

	public Task<AdventurerDto> SignUpAsync(CancellationToken cancellationToken)
	{

	}
}
