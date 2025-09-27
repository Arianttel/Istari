namespace Sauron.Application.Abstraction.Dto.Commands.Validators;
internal sealed class Constants
{
	internal sealed class Password
	{
		public const int MinLength = 12;
		public const int MaxLength = 50;
	}

	internal sealed class Name
	{
		public const int MinLength = 1;
		public const int MaxLength = 25;
	}
}
