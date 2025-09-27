namespace Sauron.Application.Abstraction.Localizations;
public static class Keys
{
	public static class Adventurer
	{
		public static class Password
		{
			public const string Length = "Adventurer:Password:Length";
			public const string MustNotEmpty = "Adventurer:Password:MustNotEmpty";
			public const string MustRepeat = "Adventurer:Password:MustRepeat";
		}

		public static class Name
		{
			public const string Length = "Adventurer:Name:Length";
			public const string MustNotEmpty = "Adventurer:Name:MustNotEmpty";
		}

		public static class RepeatPassword
		{
			public const string MustNotEmpty = "Adventurer:RepeatPassword:MustNotEmpty";
		}
	}
}
