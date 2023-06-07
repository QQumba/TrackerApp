using System.Security.Claims;
using TrackerApp.Data;

namespace TrackerApp.API.Auth;

public static class AuthContextExtensions
{
    public static void Populate(this AuthContext context, ClaimsPrincipal user)
    {
        context.IsAuthenticated = true;
        context.Login = user.FindFirstValue(ClaimsDefaults.UserName);
    }
}