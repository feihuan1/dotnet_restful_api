using RestfuleAPI.Dtos;

namespace RestfuleAPI.Endpoints;

public static class GamesEndpoints
{
    const string GetGameEdpointName = "GetGame";
    private static readonly List<GameDto> games = [
    new (
        1,
        "Street Fighter II",
        " Fighting",
        19.99M,
        new DateOnly(1992, 7, 15)
    ),
    new (
        2,
        "Final Fantasy XIV",
        "Role Playing",
        59.99M,
        new DateOnly(2010, 9, 30)
    ),
    new (
        3,
        "Mario Kart",
        " Racing",
        109.11M,
        new DateOnly(2015, 8, 20)
    ),
];

    public static RouteGroupBuilder MapGamesEndpoints(this WebApplication app)
    {

        var group = app.MapGroup("games")
                     .WithParameterValidation();// this is come from minimalApis Extensions -> validates the requirements in dtos;

        // GET /games

        group.MapGet("/", () => games);

        // GET /games/1

        group.MapGet("/{id}", (int id) =>
        {
            GameDto? game = games.Find(game => game.Id == id);

            return game is null ? Results.NotFound() : Results.Ok(game);
        })
            .WithName(GetGameEdpointName);

        //POST /games
        group.MapPost("/", (CreateGameDto newGame) =>
        {

            GameDto game = new(
                games.Count + 1,
                newGame.Name,
                newGame.Genre,
                newGame.Price,
                newGame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEdpointName, new { id = game.Id }, game);
        });
       

        // PUT /games
        group.MapPut("/{id}", (int id, UpdateGameDtos updatedGame) =>
        {
            var index = games.FindIndex(game => game.Id == id);

            if (index == -1)
            {
                return Results.NotFound();
            }

            games[index] = new GameDto(
                id,
                updatedGame.Name,
                updatedGame.Genre,
                updatedGame.Price,
                updatedGame.ReleaseDate
            );

            return Results.NoContent();
        });

        // DELETE /games/1
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(game => game.Id == id);

            return Results.NoContent();
        });

        return group;
    }
}
