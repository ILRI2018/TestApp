using NasaStars.BL.Interfaces;
using NasaStars.BL.Services;
using NasaStars.DAL;
using Microsoft.EntityFrameworkCore;
using NasaStars.DAL.Interfaces;
using NasaStars.DAL.Uow;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NasaStarsContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

builder.Services.AddScoped<IHttpHelper, HttpHelper>();
builder.Services.AddScoped<IStarService, StarService>();
builder.Services.AddScoped<IUow, Uow>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
