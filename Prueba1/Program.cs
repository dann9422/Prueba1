using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using Prueba1;
using Prueba1.Data;
using Prueba1.Services;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.

// Se hace la conecxion a la base de datos
const string CONNECTIONNAME = "Conecxion"; 
var connetionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

//se crea el contexto y se genera el servicio para consumirlo 
builder.Services.AddDbContext<UniversityDBContext>(options =>options.UseSqlServer(connetionString));


//Jwt 

builder.Services.AddJwtTokenServices(builder.Configuration);


builder.Services.AddControllers();

// se agregan los servicios de cada modelo que se quiere trabajar 
builder.Services.AddScoped<IStudentServices, StudentServices>();


//Add authorization 
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserOnlyPolicy", Policy => Policy.RequireClaim("UserOnly", "User 1"));
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
{
    Name = "Authorization",
    Type = SecuritySchemeType.Http,
    Scheme = "Bearer",
    BearerFormat = "JWT",
    In = ParameterLocation.Header,
    Description = " JWT Authorization Header using bearer scheme"
});
options.AddSecurityRequirement( new OpenApiSecurityRequirement
{

    {
        new OpenApiSecurityScheme
        {
            Reference = new OpenApiReference
            {
                Type = ReferenceType.SecurityScheme,
                Id= "Bearer",

            }
        },
        new string[]{}
    }

});
});


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
