using Microsoft.AspNetCore.Http.HttpResults;
using ParkingLotApi.Models;
using ParkingLotApi.ParkingLotExceptions;
using ParkingLotApi.Services;
using ParkingLotApi.Controllers;
using ParkingLotApi.Dtos;
using ParkingLotApi.Filters;
using ParkingLotApi.Repositories;
using System;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMvc(options =>
{
    options.Filters.Add<ParingLotFilter>();
});

builder.Services.AddScoped<ParkinglotService>();
builder.Services.AddSingleton<IParkingLotRepository, ParkingLotRepository>();

var parkingLotConfigSection = builder.Configuration.GetSection("DBConnectionSettings");

builder.Services.Configure<ParkingLotConnectionConfig>(parkingLotConfigSection);

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

public partial class Program
{
}