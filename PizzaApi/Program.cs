using AutoMapper;
using PizzaApi.Models;
using PizzaApi.Services;
using PizzaApi.Services.Implementations;
using PizzaApi.Services.Mappers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<PizzaApiDatabaseSettings>(
    builder.Configuration.GetSection("PizzaApiDatabase"));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddRazorPages();

builder.Services.AddScoped<IPizzaService, PizzaService>();
builder.Services.AddScoped<IBackupService, BackupService>();
builder.Services.AddScoped<IMemoryService, MemoryPizzaService>();
builder.Services.AddScoped<IBeverageService, BeverageService>();
builder.Services.AddScoped<IMetadataService, MetadataService>();
builder.Services.AddScoped<IMapPizza, MapPizza>();
builder.Services.AddScoped<IMapBeverage, MapBeverage>();

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);

builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllersWithViews();


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
