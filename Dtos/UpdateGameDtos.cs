using System.ComponentModel.DataAnnotations;

namespace RestfuleAPI.Dtos;

public record class UpdateGameDtos
(
    [Required][StringLength(50)] string Name,
    [Required][StringLength(20)] string Genre,
    [Range(1, 100)] decimal Price,
    [Required]DateOnly ReleaseDate
);