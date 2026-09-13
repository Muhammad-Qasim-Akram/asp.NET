using System.ComponentModel.DataAnnotations;
namespace GameStore.Api.Dtos;

public record  CreateGameDto(
    [Required] string Name,
    [Required][StringLength(10)] string Genre,
    [Range(1,100)]decimal Price,
    DateOnly ReleaseDate

);
