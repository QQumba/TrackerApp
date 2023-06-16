using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using TrackerApp.API.Endpoints;
using TrackerApp.API.Endpoints.Infrastructure;
using TrackerApp.API.Features.Issues;
using TrackerApp.API.Features.Tags;
using TrackerApp.API.Services;
using TrackerApp.Data;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.ConfigureHttpJsonOptions(o => 
    o.SerializerOptions.Converters.Add(new JsonStringEnumConverter()));

// builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
// .AddCookie(CookieAuthenticationDefaults.AuthenticationScheme);
// builder.Services.AddAuthorization();

builder.Services.AddData(builder.Configuration);

builder.Services.AddScoped<AccountService>();
builder.Services.AddIssuesFeature();
builder.Services.AddTagsFeature();

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
        var spaConfigSection = app.Configuration.GetSection("SpaDevelopmentServer");
        var spaServer = spaConfigSection["SpaServer"];
        var spaUrl = spaConfigSection[$"Url:{spaServer}"];
        x.UseProxyToSpaDevelopmentServer(spaUrl!);
    });
}

app.MapEndpoints<IssueEndpoints>("api/issues", "Issues")
    .MapEndpoints<TagEndpoints>("api/tags", "Tags");

app.Run();