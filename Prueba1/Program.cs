using Microsoft.EntityFrameworkCore;
using Prueba1.Data;
var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Se hace la conecxion a la base de datos
const string CONNECTIONNAME = "Conecxion"; 
var connetionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//se crea el contexto y se genera el servicio para consumirlo 
builder.Services.AddDbContext<UniversityDBContext>(options =>options.UseSqlServer(connetionString));
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
