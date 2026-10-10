namespace CampusFootball.Api.Matches;

public static class MatchEndpoints
{
    //Instance extension method called on the WebApp object to register the routes
    public static void MapMatchEndpoints(this IEndpointRouteBuilder app)
    {
        //Group to define endpoints with common prefix & apply shared configuration to those endpoints
        RouteGroupBuilder group = app.MapGroup("/api/matches");

        //CREATE a resource - no id in path: backend responsible for generation.
        group.MapPost("", () => "Create a Match");

        //READ
        group.MapGet("", () => "Get some matches");
        group.MapGet("{id:int}", (int id) => $"GET - single Match with id:{id}");

        //UPDATE a resource
        group.MapPatch("{id:int}", (int id) => $"PATCH - single Match with id:{id}");

        //DELETE a resource
        group.MapDelete("{id:int}", (int id) => $"DELETE - single Match with id:${id}");
    }
}
 