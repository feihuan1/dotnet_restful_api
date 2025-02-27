using RestfuleAPI.Data;
using RestfuleAPI.Endpoints;
// generate migration files
// dotnet ef migrations add InitialCreate --output-dir Data\Migrations
// excute migration
// dotnet ef database update

var builder = WebApplication.CreateBuilder(args);

var connString = builder.Configuration.GetConnectionString("GameStore"); //moved to appsetting.json
builder.Services.AddSqlite<GameStoreContext>(connString);

var app = builder.Build();

app.MapGamesEndpoints();


app.migrateDb();

app.Run();
