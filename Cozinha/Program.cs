using Cozinha.Model;
using Cozinha.Repositories;
using Cozinha.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddCors( options => {
        options.AddPolicy(name: "MyAllowSpecificOrigins",
                policy => { policy.WithOrigins("http://localhost:8080", "http://localhost:4200").AllowAnyHeader().AllowAnyMethod();
                });
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CozinhaContext>(
opt=>  opt.UseSqlite("Data Source=Database/CozinhaDB"));

builder.Services.AddScoped<IngredienteService>();
builder.Services.AddScoped<IngredienteRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("MyAllowSpecificOrigins");
app.UseAuthorization();

app.MapControllers();

app.Run();
