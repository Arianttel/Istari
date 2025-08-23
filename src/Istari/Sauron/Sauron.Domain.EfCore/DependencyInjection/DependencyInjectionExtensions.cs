using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sauron.Domain.EfCore.DependencyInjection;
public static class DependencyInjectionExtensions
{
	public static IServiceCollection AddEfCore(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddOpenIddictEfCore(configuration);
		return services;
	}

	private static IServiceCollection AddOpenIddictEfCore(this IServiceCollection services, IConfiguration configuration)
	{
		services.AddDbContext<SauronDbContext>(options =>
		{
			options.UseNpgsql(configuration.GetConnectionString(SauronEfCoreConstants.ConnectionStringName));
			options.UseOpenIddict();
		});

		services
			.AddOpenIddict()
			.AddCore(options =>
			{
				options
					.UseEntityFrameworkCore()
					.UseDbContext<SauronDbContext>();
			});

		return services;
	}
}
