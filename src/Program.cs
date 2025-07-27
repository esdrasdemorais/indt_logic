using Repository;
using Domain;
using Route = Domain.Route;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);
builder.Services.AddTransient<IRouteRepository, RouteRepository>();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

app.UseSwagger();
app.UseSwaggerUI();

var routeRepository = new RouteRepository(builder.Configuration);   

app.MapGet("/routes", () =>
{
   var routes = routeRepository.Read();
   return routes;
})
.WithName("ReadRoutes");

app.MapGet("/search-route/{origin}/{destination}", (string origin, string destination) =>
{
    var response = routeRepository.SearchRoute(origin, destination);
    return response;
})
.WithName("SearchRoute");

app.MapPost("/save-route", (Route route) =>
{
    var response = routeRepository.Create(route);
    return response;
})
.WithName("CreateRoute");

app.MapPut("/update-route", (Route route) =>
{
    var response = routeRepository.Update(route);
    return response;
})
.WithName("UpdateRoute");

app.MapDelete("/delete-route/{icaoIata}", (string icaoIata) =>
{
    var route = routeRepository.GetARoute(icaoIata);
    var response = routeRepository.Delete(route);
    return response;
})
.WithName("DeleteRoute");

app.Run();
