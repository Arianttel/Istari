using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using OpenIddict.Abstractions;
using OpenIddict.Server.AspNetCore;
using System.Security.Claims;

namespace Sauron.IdentityWebApp.Controllers;

public sealed class AuthorizationController : Controller
{
	private readonly IOpenIddictApplicationManager _appManager;

	public AuthorizationController(IOpenIddictApplicationManager appManager)
	{
		_appManager = appManager;
	}

	public async Task<IActionResult> ExchangeAsync(CancellationToken cancellationToken)
	{
		var request = HttpContext.GetOpenIddictServerRequest();

		if (request.IsClientCredentialsGrantType())
		{
			var application = await _appManager.FindByClientIdAsync(request.ClientId, cancellationToken);
			var identity = new ClaimsIdentity(
				TokenValidationParameters.DefaultAuthenticationType, 
				OpenIddictConstants.Claims.Name,
				OpenIddictConstants.Claims.Role);

			identity.SetClaim(OpenIddictConstants.Claims.Subject, await _appManager.GetClientIdAsync(application, cancellationToken));
			identity.SetClaim(OpenIddictConstants.Claims.Name, await _appManager.GetDisplayNameAsync(application, cancellationToken));

			identity.SetDestinations(static claim => claim.Type switch
			{
				OpenIddictConstants.Claims.Name when 
					claim.Subject.HasScope(OpenIddictConstants.Scopes.Profile) => 
						[OpenIddictConstants.Destinations.AccessToken, OpenIddictConstants.Destinations.IdentityToken],
				_ => [OpenIddictConstants.Destinations.IdentityToken]
			});

			return SignIn(new ClaimsPrincipal(identity), OpenIddictServerAspNetCoreDefaults.AuthenticationScheme);
		}

		throw new NotImplementedException("The specified grant is not implemented.");
	}
}
