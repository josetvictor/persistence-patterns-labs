using System.Data;

using PatternsLabs.Repository;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/user", async (AppDbContext context, UserDTO userDto) => {
    var service = new UserService(context);
    var user = await service.SaveUser(userDto);
    return Results.Created($"/user/{user.Id}", user);
});

app.MapGet("/user/{id}", async (AppDbContext context, string id) => {
    var service = new UserService(context);
    var user = await service.GetUserAsync(Guid.Parse(id));
    return Results.Ok(user);
});

app.MapGet("/user", async (AppDbContext context) => {
    var service = new UserService(context);
    var users = await service.GetAllAsync();
    return Results.Ok(users);
});

app.MapPut("/user/{id}/block", async (AppDbContext context, string id) => {
    var service = new UserService(context);
    var user = await service.BlockedUser(Guid.Parse(id));
    return Results.Ok(user);
});

app.MapPut("/user/{id}/admin", async (AppDbContext context, string id) => {
    var service = new UserService(context);
    var user = await service.BlockedUser(Guid.Parse(id));
    return Results.Ok(user);
});

app.Run();
