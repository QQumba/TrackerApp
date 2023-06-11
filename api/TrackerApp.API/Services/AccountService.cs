using System.Collections.Generic;
using TrackerApp.API.Endpoints;
using TrackerApp.Data;

namespace TrackerApp.API.Services;

public class AccountService
{
    private readonly Dictionary<string, SigninDto> _users = new();

    private readonly AuthContext _authContext = new();

    public SigninDto? CreateUser(SigninDto signinDto)
    {
        if (_users.ContainsKey(signinDto.Login))
        {
            return null;
        }

        _users.Add(signinDto.Login, signinDto);
        return signinDto;
    }

    public SigninDto? GetUserByLogin(string login)
    {
        return _users.TryGetValue(login, out var user) ? user : null;
    }

    public SigninDto? GetUser()
    {
        return _authContext.Login is null ? null : GetUserByLogin(_authContext.Login);
    }
}