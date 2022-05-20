using Microsoft.EntityFrameworkCore;
using MyBoards.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<MyBoardsContext>(
    option => option.UseSqlServer(builder.Configuration.GetConnectionString("MyBoardsConnectionString"))
    );


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
// sprawdzenie czy baza jest z danymi jesli nie to jest wykonywana migracja
using var scope = app.Services.CreateScope();
var dbContex = scope.ServiceProvider.GetService<MyBoardsContext>();
var pendingMigration = dbContex.Database.GetPendingMigrations();
if(pendingMigration.Any())
{
    dbContex.Database.Migrate();
}

var users = dbContex.Users.ToList();

if(!users.Any())
{
    var user1 = new User()
    {
        Email = "test@test.pl",
        FullName = "User One",
        Address = new Address()
        {
            City = "Warszawa",
            Street = "Szeroka"
        }
    };

    var user2 = new User()
    {
        Email = "test1@test.pl",
        FullName = "User two",
        Address = new Address()
        {
            City = "Katowice",
            Street = "Górna"
        }
    };

    dbContex.Users.AddRange(user1, user2);
    dbContex.SaveChanges();

}

app.Run();

