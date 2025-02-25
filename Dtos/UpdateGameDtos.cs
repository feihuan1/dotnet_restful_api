namespace RestfuleAPI.Dtos;

public record class UpdateGameDtos
(
    string Name,
    string Genre,
    decimal Price,
    DateOnly ReleaseDate
);