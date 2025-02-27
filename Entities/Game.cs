
namespace RestfuleAPI.Entities;

public class Game
{
    public int Id { get; set; }

    public required string Name { get; set; }

    //folowing 2 prop required to have relationship with genre table
    public int GenreId { get; set; }
    public Genre? Genre {get; set;}

    public decimal Price { get; set; }

    public DateOnly ReleaseDate {get; set;}
}
