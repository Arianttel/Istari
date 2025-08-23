using OpenIddict.Abstractions;
using Sauron.Domain.EfCore;

namespace Sauron.IdentityWebApp.Background;
public sealed class DistributorClientsWorker : IHostedService
{
	private readonly IServiceProvider _serviceProvider;

	public DistributorClientsWorker(IServiceProvider serviceProvider)
	{
		_serviceProvider = serviceProvider;
	}

	public async Task StartAsync(CancellationToken cancellationToken)
	{
		using var scope = _serviceProvider.CreateScope();

		var context = scope.ServiceProvider.GetRequiredService<SauronDbContext>();
		await context.Database.EnsureCreatedAsync(cancellationToken);

		var manager = scope.ServiceProvider.GetRequiredService<IOpenIddictApplicationManager>();

		if (await manager.FindByClientIdAsync("test-worker") is null)
		{
			await manager.CreateAsync(new OpenIddictApplicationDescriptor()
			{
				ClientId = "test-worker",
				ClientSecret = "test",
				Permissions =
				{
					OpenIddictConstants.Permissions.Endpoints.Token,
					OpenIddictConstants.Permissions.GrantTypes.ClientCredentials
				}
			});
		}
	}

	public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
