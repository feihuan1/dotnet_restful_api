using RestfuleAPI.Dtos;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

const string GetGameEdpointName = "GetGame";

List<GameDto> games = [
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

// GET /games

app.MapGet("games", () => games);

// GET /games/1

app.MapGet("games/{id}", (int id) => 
{
    GameDto? game = games.Find(game => game.Id == id);

    return game is null? Results.NotFound() : Results.Ok(game);
})
    .WithName(GetGameEdpointName);

//POST /games
app.MapPost("games", (CreateGameDto newGame) => {
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);

    return Results.CreatedAtRoute(GetGameEdpointName, new {id = game.Id}, game);
});

// PUT /games
app.MapPut("games/{id}",(int id, UpdateGameDtos updatedGame)=> 
{
    var index = games.FindIndex(game => game.Id == id);

    if(index == -1)
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
app.MapDelete("games/{id}", (int id) => 
{
    games.RemoveAll(game => game.Id == id);

    return Results.NoContent();
});

app.Run();
