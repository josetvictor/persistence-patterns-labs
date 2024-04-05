using PatternsLabs.DAO;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<AppDbContext>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();

app.MapPost("/user", (AppDbContext context, User user) => {
    var service = new UserService(context);
    service.SaveUser(user);
    return Results.Created();
});

app.MapGet("/user/{id}", (AppDbContext context, string id) => {
    var service = new UserService(context);
    var user = service.GetUser(Guid.Parse(id));
    return Results.Ok(user);
});

app.MapPost("/user/{id}/block", (AppDbContext context, string id) => {
    var service = new UserService(context);
    service.BlockedUser(Guid.Parse(id));
    return Results.NoContent();
});

app.MapPost("/user/{id}/admin", (AppDbContext context, string id) => {
    var service = new UserService(context);
    service.BlockedUser(Guid.Parse(id));
    return Results.NoContent();
});

app.Run();
