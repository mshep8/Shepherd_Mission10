/*
Mary Catherine Shepherd
IS 413
Mission 10

This file configures and starts the ASP.NET Web API application.
It sets up services such as controllers, the database connection,
the repository, CORS for the React frontend, and Swagger for API testing.
*/

using Microsoft.EntityFrameworkCore;
using Shepherd_Mission10.Data;

// Create a builder that sets up the web application
var builder = WebApplication.CreateBuilder(args);

// Add controller support so the API can handle HTTP requests
builder.Services.AddControllers();

// Configure Entity Framework to use the SQLite database
// The connection string comes from appsettings.json
builder.Services.AddDbContext<BowlingLeagueContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("BowlingConnection")));

// Register the repository with dependency injection
// This allows controllers to request IBowlingRepository
// and automatically receive EFBowlingRepository
builder.Services.AddScoped<IBowlingRepository, EFBowlingRepository>();

// Configure CORS (Cross-Origin Resource Sharing)
// This allows the React frontend running on localhost:5173
// to make requests to the ASP.NET API
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp", policy =>
    {
        policy.WithOrigins("http://localhost:5173")
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});

// Add services needed for Swagger (API testing interface)
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Build the application
var app = builder.Build();

// Enable Swagger only in development mode
// This allows testing API endpoints through a web interface
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Enable the CORS policy we created earlier
app.UseCors("AllowReactApp");

// Redirect HTTP requests to HTTPS for security
app.UseHttpsRedirection();

// Map controller routes so the API endpoints work
app.MapControllers();

// Start the web application
app.Run();