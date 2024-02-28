using FluentValidation;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.EntityFrameworkCore;
using Proyecto_01.DTOs;
using Proyecto_01.Models;
using Proyecto_01.Services;
using Proyecto_01.Validators;

var builder = WebApplication.CreateBuilder(args);




// Add services to the container.
builder.Services.AddKeyedScoped<ICommonService<ProductoDto,ProductoInsertDto,ProductoUpdateDto>, ProductosService>("productosService");



//Configuracion e inyeccion de DbContext Entity Framework
builder.Services.AddDbContext<StoreContext>(options =>
{
    options.UseMySql(builder.Configuration.GetConnectionString("DbConnection"), ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("DbConnection")));
});

//Validators
builder.Services.AddScoped<IValidator<ProductoInsertDto> , ProductoInsertValidator>();


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
