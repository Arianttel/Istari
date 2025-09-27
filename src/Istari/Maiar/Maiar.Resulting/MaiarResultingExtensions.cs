using Maiar.Resulting.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Maiar.Resulting;
public static class MaiarResultingExtensions
{
	public static IServiceCollection AddMaiarResulting(this IServiceCollection services)
	{
		services.AddSingleton<IResolver, Resolver>();
		return services;
	}
}
