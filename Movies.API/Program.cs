using Microsoft.EntityFrameworkCore;

using Movies.API.Data;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<MoviesAPIContext>(options =>
    options.UseInMemoryDatabase("Movies"));

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5005";
        options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
        {
            ValidateAudience = false,
        };
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("ClientPolicy", policy => policy.RequireClaim("client_id", "movieClient"));
});


var app = builder.Build();

var scope = app.Services.CreateScope();
var services = scope.ServiceProvider;
var moviesContext = services.GetRequiredService<MoviesAPIContext>();
MoviesContextSeed.SeedAsync(moviesContext);


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
