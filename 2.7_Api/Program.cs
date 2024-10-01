using _2._7_back.Data.Models;
using _2._7_back.Repository;
using _2._7_back.Service;
using Microsoft.EntityFrameworkCore;


var builder = WebApplication.CreateBuilder(args);














builder.Services.AddDbContext<TurnosContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IServicioRepository, ServicioRepository>();

builder.Services.AddScoped<IServiceServicio, ServiceServicio>();













// Add services to the container.

builder.Services.AddControllers();
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
