namespace GameStore.Api.Dtos;

public record  GameSummaryDto(
    int Id,
    String Name,
    String Genre,
    decimal Price,
    DateOnly ReleaseDate
);

