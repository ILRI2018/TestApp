using NasaStars.BL.Interfaces;
using NasaStars.BL.Services;
using NasaStars.DAL;
using Microsoft.EntityFrameworkCore;
using NasaStars.DAL.Interfaces;
using NasaStars.DAL.Uow;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options =>
{
    options.SerializerSettings.ContractResolver = new DefaultContractResolver();
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
builder.Services.AddDbContext<NasaStarsContext>(x => x.UseSqlServer(connectionString));

builder.Services.AddHttpContextAccessor();
builder.Services.AddHttpClient();

var mapperConfig = new AutoMapper.MapperConfiguration(mc =>
{
    mc.AddProfile(new NasaStars.API.MapperProfile());
});

AutoMapper.IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

builder.Services.AddTransient(typeof(IGenericRepository<>), typeof(NasaStars.DAL.Repositories.GenericRepository<>));

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
app.UseCors();

app.MapControllers();


app.Run();
