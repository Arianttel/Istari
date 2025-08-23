using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sauron.Domain.EfCore.DependencyInjection;

namespace Sauron.Abstraction;
public static class Application
{
	public static IServiceCollection AddSauron(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddEfCore(configuration);
		services.AddOpenIddictServer();

		return services;
	}
}
