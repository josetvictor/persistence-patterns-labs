using PatternsLabs.ActiveRecord;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/user", (User user) => {
    var service = new UserService();
    service.SaveUser(user);
    return Results.Created();
});

app.MapGet("/user/{id}", (string id) => {
    var service = new UserService();
    var user = service.GetUser(Guid.Parse(id));
    return Results.Ok(user);
});

app.MapPost("/user/{id}/block", (string id) => {
    var service = new UserService();
    service.BlockedUser(Guid.Parse(id));
    return Results.NoContent();
});

app.MapPost("/user/{id}/admin", (string id) => {
    var service = new UserService();
    service.BlockedUser(Guid.Parse(id));
    return Results.NoContent();
});

app.Run();
