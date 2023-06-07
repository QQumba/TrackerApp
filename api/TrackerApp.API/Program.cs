using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrackerApp.API.Auth;
using TrackerApp.API.Endpoints;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.Features.Issues;
using TrackerApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
// .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
// builder.Services.AddAuthorization();

builder.Services.AddData(builder.Configuration);

builder.Services.AddIssuesFeature();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();

// app.UseAuthentication();
// app.UseAuthorization();

#pragma warning disable ASP0014
// Ensures the correct order of middleware when used with SPA proxy
app.UseEndpoints(_ => { });
#pragma warning restore ASP0014

app.UseHttpsRedirection();

if (app.Environment.IsDevelopment())
{
    app.UseSpa(x =>
    {
        const string angularUri = "http://localhost:4200";
        x.UseProxyToSpaDevelopmentServer(angularUri);
    });
}

app.MapEndpoints<IssueEndpoints>("api/issues", "Issues")
    .MapEndpoints<LibraryEndpoints>("api/library", "Library");

app.Run();