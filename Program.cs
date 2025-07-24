using uttt.Micro.Libro.Extensiones;

var builder = WebApplication.CreateBuilder(args);

// Obtiene las cadenas de conexión desde variables de entorno
var writeConnection = builder.Configuration["ConnectionStrings:DefaultConnection"];
var readConnection = builder.Configuration["ConnectionStrings:DbGlobalConnection"];

// Debug: Verifica las cadenas de conexión
Console.WriteLine($"Write Connection: {writeConnection}");
Console.WriteLine($"Read Connection: {readConnection}");

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// lee las cadenas del appsettings
//builder.Services.AddCustomServices(builder.Configuration);

// Pasa las cadenas de conexión directamente
builder.Services.AddCustomServices(writeConnection, readConnection);


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
