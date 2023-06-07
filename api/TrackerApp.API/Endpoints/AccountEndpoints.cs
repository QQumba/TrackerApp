using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TrackerApp.API.Auth;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.Services;

namespace TrackerApp.API.Endpoints;

public class AccountEndpoints : IEndpointsDefinition
{
    public void MapEndpoints(IEndpointRouteBuilder routeBuilder, string prefix, string swaggerGroup)
    {
        var builder = routeBuilder.MapGroup(prefix).WithTags(swaggerGroup);
        
        builder.MapPost("/signin", Signin);
        builder.MapPost("/login", Login);
        builder.MapGet("/user-info", GetUserInfo)
            .RequireAuthorization();
    }

    public static async Task<IResult> Signin(SigninDto signinDto, HttpContext context, UserRepository repository)
    {
        var user = repository.CreateUser(signinDto);
        if (user is null)
        {
            return Results.BadRequest("User already signed in. Try login instead.");
        }

        await SignInAsync(context, signinDto);
        return Results.Ok(signinDto);
    }

    public static async Task<IResult> Login(SigninDto signinDto, HttpContext context, UserRepository repository)
    {
        var user = repository.GetUserByLogin(signinDto.Login);

        if (user is null || user.Password != signinDto.Password)
        {
            return Results.BadRequest("Invalid login or password.");
        }

        await SignInAsync(context, user);
        return Results.Ok();
    }

    public static IResult GetUserInfo(UserRepository repository)
    {
        var user = repository.GetUser();
        return Results.Ok(user);
    }

    private static async Task SignInAsync(HttpContext context, SigninDto signinDto)
    {
        var claims = new ClaimsPrincipal(
            new ClaimsIdentity(
                new Claim[]
                {
                    new(ClaimsDefaults.UserName, signinDto.Login)
                },
                CookieAuthenticationDefaults.AuthenticationScheme));

        var props = new AuthenticationProperties
        {
            IsPersistent = true
        };

        await context.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, claims, props);
    }
}

public record SigninDto(string Login, string Password);