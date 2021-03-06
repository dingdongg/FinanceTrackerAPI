global using FinanceTrackerAPI.Data;
global using Microsoft.EntityFrameworkCore;
using AutoMapper;
using FinanceTrackerAPI.Profiles;
using FinanceTrackerAPI.Repository;
using Newtonsoft.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(s =>
{
    s.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
});

builder.Services.AddAutoMapper(typeof(TransactionsProfile));

// registers the mock repo implementation to its interface (for now)
builder.Services.AddScoped<ITransactionRepo, SqlTransactionRepo>();

builder.Services.AddDbContext<DataContext>(options =>
{
    // connection to SQL Server using the connection string
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
