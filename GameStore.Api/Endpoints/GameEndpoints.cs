using GameStore.Api.Dtos;
using GameStore.Api.Data;

namespace GameStore.Api.Endpoints;
public static class GameEndpoints
{
    const string GetGameEndpoint = "GetGame";
    private static readonly List<GameDto> games = [
    new (1,
    "Street Fighter",
    "Fighting",
    26.36M,
    new DateOnly(2006,04,13)

   ),
    new (2,
    "Tekken 8",
    "Fighting",
    69.99M,
    new DateOnly(2024, 01, 26)
   ),
   new (3,
    "The Legend of Zelda: Breath of the Wild",
    "Adventure",
    59.99M,
    new DateOnly(2017, 03, 03)
    ),
    new (4,
    "Elden Ring",
    "RPG",
    59.99M,
    new DateOnly(2022, 02, 25)
    ),
    new (5,
    "Cyberpunk 2077",
    "Sci-Fi RPG",
    49.99M,
    new DateOnly(2020, 12, 10)
    ),
    new (6,
    "Hades",
    "Roguelike",
    24.99M,
    new DateOnly(2020, 09, 17)
    )
    ];

    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");
        //get/games
        group.MapGet("/", () => games);

        // get/games/1
        group.MapGet("/{id}", (int id) =>
        {

            var game = games.FirstOrDefault(games => games.Id == id);
            return game is null ? Results.NotFound() : Results.Ok(game);

        }).WithName(GetGameEndpoint);

        //post/games
        group.MapPost("/", (CreateGameDto newgame,GameStoreContext dbcontext) =>
        {
            Game game = new(
                games.Count + 1,
                newgame.Name,
                newgame.Genre,
                newgame.Price,
                newgame.ReleaseDate
            );
            games.Add(game);

            return Results.CreatedAtRoute(GetGameEndpoint, new { id = game.Id }, game);
        });

        //put /games/1
        group.MapPut("/{id}", (int id, UpdateGameDto updatedGame) =>
        {
            var index = games.FindIndex(games => games.Id == id);

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

        //delete games/1
        group.MapDelete("/{id}", (int id) =>
        {
            games.RemoveAll(games => games.Id == id);
            return Results.NoContent();
        });
    }
}
