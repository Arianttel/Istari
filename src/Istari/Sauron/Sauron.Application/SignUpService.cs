using Maiar.FluentValidator.Abstraction;
using Maiar.Resulting.Abstraction;
using Sauron.Application.Abstraction.Dto;
using Sauron.Application.Abstraction.Dto.Commands;
using Sauron.Domain.Adventurers;

namespace Sauron.Application;
internal sealed class SignUpService
{
	private readonly IAdventurerRepository _adventurerRepository;
	private readonly IResolver _resolver;
	private readonly IValidator<SignUp> _signUpValidator;

	public SignUpService(
		IAdventurerRepository adventurerRepository,
		IResolver resolver,
		IValidator<SignUp> signUpValidator)
	{
		_adventurerRepository = adventurerRepository;
		_resolver = resolver;
		_signUpValidator = signUpValidator;
	}

	public async Task<Result<AdventurerDto>> SignUpAsync(SignUp command, CancellationToken cancellationToken)
	{
		var validationResult = await _signUpValidator.ValidateAsync(command, cancellationToken);
		if (!validationResult.IsSuccess)
		{
			return Result<AdventurerDto>.FromError(validationResult);
		}

		
	}
}
