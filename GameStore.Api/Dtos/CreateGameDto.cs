using System.ComponentModel.DataAnnotations;
namespace GameStore.Api.Dtos;

public record  CreateGameDto(
    [Required] string Name,
    [Range(1,50)] int GenreId,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate

);
