using FluentValidation;
using Services;
using Services.Abstractions;
using Services.Configuration;
using Services.DataAccess;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICamerasFileReader, CamerasFileReader>();
builder.Services.AddScoped<ICameraService, CamerasService>();
builder.Services.AddScoped<ICameraFactory, CameraFactory>();
builder.Services.AddScoped<IValidator<CameraFileRecord>, CameraFileRecordValidator>();
builder.Services.Configure<CamerasFileConfiguration>(builder.Configuration.GetSection(CamerasFileConfiguration.SectionName));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseCors(options => 
        options
            .WithOrigins("http://localhost:9080")
            .AllowAnyMethod()
            .AllowAnyHeader());
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
