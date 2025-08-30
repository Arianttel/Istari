using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Sauron.Domain.EfCore;
using Sauron.Domain.EfCore.DependencyInjection;

var host = Host.CreateApplicationBuilder(args);
host.Services.AddEfCore(host.Configuration);
var application = host.Build();

await using (var scope = application.Services.CreateAsyncScope())
{
	var logger = scope.ServiceProvider.GetRequiredService<ILogger<Program>>();
	
	logger.LogInformation("Run migrations");
	var sauronContext = scope.ServiceProvider.GetRequiredService<SauronDbContext>();
	await sauronContext.Database.MigrateAsync();
	logger.LogInformation("Migrations end");
}

