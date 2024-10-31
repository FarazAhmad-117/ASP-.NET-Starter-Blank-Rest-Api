using GameStore.Api.Dtos;

var builder = WebApplication.CreateBuilder(args);

// Area to configure all the services



var app = builder.Build();

List<GameDto> games = [
    new(
        1,
        "Street Fighter II",
        "Fighting",
        19.99M, // M to indicate decimal
        new DateOnly(1992, 7, 15)
    ),
    new(
        2,
        "Super Mario Bros.",
        "Platforming",
        10.99M,
        new DateOnly(1985, 3, 25)
    ),
    new (
        3,
        "Tetris",
        "Puzzle",
        6.99M,
        new DateOnly(1989, 1, 1)
    )
];


app.MapGet("/", () => "Hello World!");
app.MapGet("/api", () => "Hello Api!");
// GET: /games 
app.MapGet("games", () => games);


// GET: /game/:id
app.MapGet("/game/{id}", (int id) => games.Find(game => game.Id == id));

// POST: /game
app.MapPost("/game", (CreateGameDto newGame) =>
{
    GameDto game = new(
        games.Count + 1,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );
    games.Add(game);
    return game;
});


// PUT: /game/:id
app.MapPut("/game/{id}", (int id, UpdateGameDto newGame) =>
{
    int index = games.FindIndex(g => g.Id == id);
    if (index == -1)
    {
        return Results.NotFound();
    }

    GameDto updatedGame = new(
        id,
        newGame.Name,
        newGame.Genre,
        newGame.Price,
        newGame.ReleaseDate
    );

    games[index] = updatedGame;
    return Results.Ok(updatedGame);
});


// For some json data
app.MapGet("/data", () => new
{
    success = true,
    message = "Hello Boi",
    Time = DateTime.Now
});


app.Run();
