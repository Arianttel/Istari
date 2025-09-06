using Maiar.Dapper.Abstraction;
using Microsoft.Extensions.DependencyInjection;

namespace Maiar.Dapper;
public static class MaiarDapperExtensions
{
	public static IServiceCollection AddMaiarDapper(this IServiceCollection services)
	{
		services.AddSingleton<IMaiarConnectionFactory, MaiarConnectionFactory>();
		return services;
	}
}
