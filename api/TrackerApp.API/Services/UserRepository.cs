using System.Collections.Generic;
using TrackerApp.API.Endpoints;
using TrackerApp.Data;

namespace TrackerApp.API.Services;

public class UserRepository
{
    private readonly Dictionary<string, SigninDto> _users;

    private readonly AuthContext _authContext;

    public UserRepository(AuthContext authContext, Database database)
    {
        _authContext = authContext;
        _users = database;
    }

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