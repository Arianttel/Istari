namespace Sauron.Application.Abstraction.Dto.Commands;
public sealed class SignUp
{
	public required string Name { get; init; }
	public required string Password { get; init; }
	public required string RepeatPassword { get; init; }
}
