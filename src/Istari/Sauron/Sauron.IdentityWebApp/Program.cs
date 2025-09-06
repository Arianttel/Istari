using Sauron.Abstraction;
using Sauron.IdentityWebApp.Background;
using Sauron.IdentityWebApp.Components;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services
	.AddRazorComponents()
	.AddInteractiveServerComponents();

builder.Services.AddControllers();
builder.Services.AddSauron(builder.Configuration);
builder.Services.AddHostedService<DistributorClientsWorker>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
	app.UseExceptionHandler("/Error", createScopeForErrors: true);
	// The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
	app.UseHsts();
}

// TODO Configure CORS
//app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.UseRouting();
app.MapControllers();

app.UseHttpsRedirection();

app.UseStaticFiles();
app.UseAntiforgery();

app.MapRazorComponents<App>()
		.AddInteractiveServerRenderMode();

app.Run();
