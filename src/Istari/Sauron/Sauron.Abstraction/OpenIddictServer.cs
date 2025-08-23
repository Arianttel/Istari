using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sauron.Domain.EfCore.DependencyInjection;

namespace Sauron.Abstraction;
internal static class OpenIddictServer
{
	public static IServiceCollection AddOpenIddictServer(this IServiceCollection services)
	{
		services
			.AddOpenIddict()
			.AddServer(options =>
			{
				options.SetTokenEndpointUris("connect/token");
				
				options
					.AllowClientCredentialsFlow();

				options
					.AddDevelopmentEncryptionCertificate()
					.AddDevelopmentSigningCertificate();

				options
					.UseAspNetCore()
					.EnableTokenEndpointPassthrough();
			});

		return services;
	}
}
