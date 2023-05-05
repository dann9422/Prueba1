using Microsoft.EntityFrameworkCore;
using Prueba1.Data;
using Prueba1.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Se hace la conecxion a la base de datos
const string CONNECTIONNAME = "Conecxion"; 
var connetionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//se crea el contexto y se genera el servicio para consumirlo 
builder.Services.AddDbContext<UniversityDBContext>(options =>options.UseSqlServer(connetionString));
builder.Services.AddControllers();

// se agregan los servicios de cada modelo que se quiere trabajar 
builder.Services.AddScoped<IStudentServices, StudentServices>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


//habilitar el cors para controlar quienes pueden hacer las peticiones al api

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin();
        builder.AllowAnyMethod();
        builder.AllowAnyHeader();
    });
});
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

// use los cors
app.UseCors("CorsPolicy");

app.Run();
