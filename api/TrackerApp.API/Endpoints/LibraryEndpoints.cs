using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using TrackerApp.API.Endpoints.Infrastructure;

namespace TrackerApp.API.Endpoints;

public class LibraryEndpoints : IEndpointsDefinition
{
    public void MapEndpoints(IEndpointRouteBuilder routeBuilder, string prefix, string swaggerGroup)
    {
        var builder = routeBuilder.MapGroup(prefix).WithTags(swaggerGroup);
        MapEndpoints(builder);
    }

    public void MapEndpoints(RouteGroupBuilder builder)
    {
        builder.MapGet("books/all", GetBooks)
            .Produces<Book[]>()
            .WithOpenApi("Get books", "Returns all available books");

        builder.MapGet("books", GetBookByAuthor)
            .Produces<Book>()
            .Produces(404)
            .WithOpenApi("Get book", "Get book by author name")
            .WithParameter(0, "Author of the book");
    }

    private readonly Book[] _books =
    {
        new() { Title = "Harry Potter", Author = "JR" },
        new() { Title = "Witcher", Author = "Sapkovsii" },
        new() { Title = "The magic mountain", Author = "Thomas Mann" },
    };

    private IResult GetBooks()
    {
        return Results.Ok(_books);
    }

    private IResult GetBookByAuthor(string author)
    {
        var book = _books.FirstOrDefault(x => x.Author == author);
        return book is null ? Results.NotFound() : Results.Ok(book);
    }
}

public record Book
{
    public string Title { get; init; } = null!;

    public string Author { get; init; } = null!;
}