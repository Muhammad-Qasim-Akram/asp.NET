using Microsoft.EntityFrameworkCore;
using GameStore.Api.Models;

namespace GameStore.Api.Data;

public static class DataExtensions
{
    public static void MigrateDb(this WebApplication app)
    {
        using var scope = app.Services.CreateScope();
        var dbcontext = scope.ServiceProvider.GetRequiredService<GameStoreContext>();
        dbcontext.Database.Migrate();
    }

    public static void AddGameStoreDb(this WebApplicationBuilder builder)
    {
        var connString = builder.Configuration.GetConnectionString("GameStore");
        builder.Services.AddSqlite<GameStoreContext>(
         connString,
         optionsAction: options => options.UseSeeding((context, _) =>
         {
           if (!context.Set<Genre>().Any())
             {
              context.Set<Genre>().AddRange(
                
                 new Genre{Name = "Action"},
                 new Genre{Name = "Adventure"},
                 new Genre{Name = "Racing"},
                 new Genre{Name = "Open-World"}
             );
             context.SaveChanges();
         }
     })
    );
    }
}
