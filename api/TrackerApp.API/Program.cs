using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrackerApp.API.Auth;
using TrackerApp.API.Endpoints;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.ResultTest;
using TrackerApp.API.Services;
using TrackerApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
builder.Services.AddAuthorization();

builder.Services.AddScoped<AuthContext>();
builder.Services.AddScoped<UserRepository>();
builder.Services.AddSingleton<Database>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.UseAuthContextPopulation();

#pragma warning disable ASP0014
// Ensures the correct order of middleware when used with SPA proxy
app.UseEndpoints(_ => { });
#pragma warning restore ASP0014

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSpa(x =>
    {
        // var angularUri = "http://localhost:4200";
        const string vueUri = "http://127.0.0.1:5173";
        x.UseProxyToSpaDevelopmentServer(vueUri);
    });
}

app
    .MapEndpoints<ResultTestEndpoints>("api/test", "Test")
    .MapEndpoints<LibraryEndpoints>("api/library", "Library")
    .MapEndpoints<IssueTrackerEndpoints>("api/issues", "Issues");

app.Run();