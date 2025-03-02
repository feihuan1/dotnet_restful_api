using Microsoft.EntityFrameworkCore;
using RestfuleAPI.Entities;

namespace RestfuleAPI.Data;

public class GameStoreContext(DbContextOptions<GameStoreContext> options) 
    : DbContext(options)
{
    public DbSet<Game> Games => Set<Game>();

    public DbSet<Genre> Genres => Set<Genre>();

}
