using ChuckNoris.Api.DAL;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddDbContext<ChuckContext>(opts => opts.UseSqlite(builder.Configuration.GetConnectionString("ChuckDatabase")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(opts =>
{
	opts.AddDefaultPolicy(policy =>
	{
		policy
		.AllowAnyMethod()
		.AllowAnyHeader()
		.AllowCredentials()
		.WithOrigins(builder.Configuration.GetValue<string>("AllowedOrigins"));
	});
});

var app = builder.Build();

app.UseCors();
app.UseSwagger();
app.UseSwaggerUI();

app.UseAuthorization();

app.MapControllers();

app.Run();
