using GameStore.Api.Dtos;
using GameStore.Api.Data;
using GameStore.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace GameStore.Api.Endpoints;
public static class GameEndpoints
{
    const string GetGameEndpoint = "GetGame";
  
    public static void MapGamesEndpoints(this WebApplication app)
    {
        var group = app.MapGroup("/games");


        //get/games
        group.MapGet("/",async (GameStoreContext dbcontext) =>
          await dbcontext.Games
               .Include(game => game.Genre)
               .Select(
                  game => new GameSummaryDto(
                  game.Id,
                  game.Name,
                  game.Genre.Name,
                  game.Price,
                  game.ReleaseDate
             )).AsNoTracking()
               .ToListAsync()  );


        // get/games/1
        group.MapGet("/{id}", async (int id,GameStoreContext dbcontext) =>
        {
            var game = await dbcontext.Games.FindAsync(id);
            return game is null ? Results.NotFound() : Results.Ok(
             
                new GameDetailsDto(
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            )
            );
        }).WithName(GetGameEndpoint);


        //post/games
        group.MapPost("/",async (CreateGameDto newgame,GameStoreContext dbcontext) =>
        {
            Game game = new()
           { 
              Name = newgame.Name,
              GenreId = newgame.GenreId,
              Price = newgame.Price,
              ReleaseDate = newgame.ReleaseDate
          };
        
            dbcontext.Games.Add(game);
            await dbcontext.SaveChangesAsync();
 
            GameDetailsDto gameDto = new (
                game.Id,
                game.Name,
                game.GenreId,
                game.Price,
                game.ReleaseDate
            );
            return Results.CreatedAtRoute(GetGameEndpoint, new { id = gameDto.Id }, gameDto);
        });


        //put /games/1
        group.MapPut("/{id}", async (int id, UpdateGameDto updatedGame,GameStoreContext dbcontext) =>
        {
            var existingGame = await dbcontext.Games.FindAsync(id);
            if (existingGame is null)
            {
                return Results.NotFound();
            }
           existingGame.Name = updatedGame.Name;
           existingGame.GenreId = updatedGame.GenreId;
           existingGame.Price = updatedGame.Price;
           existingGame.ReleaseDate = updatedGame.ReleaseDate;

           await dbcontext.SaveChangesAsync();

            return Results.NoContent();
        });

        //delete games/1
        group.MapDelete("/{id}",async (int id,GameStoreContext dbcontext) =>
        {
            await dbcontext.Games.Where(games => games.Id == id).ExecuteDeleteAsync();
            return Results.NoContent();

        });
    }
}
