using ThyreSoft.Photobooth.Core.IServices;
using Thyrsoft.Photobooth.DataAcess.Repositories;
using ThyrSoft.Photobooth.Domain.IRepositories;
using ThyrSoft.Photobooth.Domain.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IPhotoService, PhotoService>();
builder.Services.AddScoped<IPhotoRepository, PhotoRepository>();

// Cors
builder.Services.AddCors(options => {
    options.AddPolicy("dev-cors", policy => {
        policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseCors("dev-cors");
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();