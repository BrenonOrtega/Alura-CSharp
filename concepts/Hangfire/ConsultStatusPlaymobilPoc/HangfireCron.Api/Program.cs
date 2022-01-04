using HangfireCron.Api;
using HangfireCron.Api.Services.Paybill;
using HangfireCron.Infra.Data.Repositories;
using HangfireCron.Infra.Extensions;
using HangfireCron.Shared;
using HangfireCron.Shared.Models;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;
// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPaybillService, PaybillService>();
builder.Services.AddScoped(typeof(IAsyncRepository<PaybillStatusConsult>),typeof(PaybillStatusConsultRepository));
builder.Services.AddScoped<PaybillConsultHandler>();

builder.Services.AddRecurrentHangfireJob(configuration);
builder.Services.AddRedisCaching(configuration);

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
