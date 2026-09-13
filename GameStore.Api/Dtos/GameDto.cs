namespace GameStore.Api.Dtos;

public record  GameDto(
    int Id,
    String Name,
    String Genre,
    decimal Price,
    DateOnly ReleaseDate
);

