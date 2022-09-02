global using AutoMapper;
using BeruTask.Server.DataAccess;
using BeruTask.Server.DTOs;
using BeruTask.Server.Models;
using BeruTask.Server.Repository;
using BeruTask.Server.Repository.Interfaces;
using BeruTask.Server.Services;
using BeruTask.Server.Services.Interfaces;
using BeruTask.Shared;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();
IMapper mapper = new MapperConfiguration((Action<IMapperConfigurationExpression>)(cfg =>
{
    cfg.CreateMap<GoldPriceModel, GoldPriceJsonDto>();
    cfg.CreateMap<GoldPriceDto, GoldPriceModel>();
    cfg.CreateMap<GoldPriceModel, GoldPriceDto>();
})).CreateMapper();

builder.Services.AddSingleton(mapper);
builder.Services.AddDbContext<GoldPriceContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("default")));

builder.Services.AddScoped<IGetDataService, GetDataService>();
builder.Services.AddScoped<ISaveDataService, SaveDataService>();
builder.Services.AddScoped<IGoldPriceRepo, GoldPriceRepo>();

builder.Services.AddHttpClient("nbp", (Action<HttpClient>)(c =>
{
    c.BaseAddress = new Uri("http://api.nbp.pl/api/cenyzlota/");
    c.DefaultRequestHeaders.Add("Accept", "application/json");
}));


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();


app.MapRazorPages();
app.MapControllers();
app.MapFallbackToFile("index.html");

app.Run();
