using Clinica.API.Middleware;
using Clinica.Application.Ioc;
using Clinica.Application.Mappings;
using Clinica.Infrastructure.Ioc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Load AutoMapper.
builder.Services.AddAutoMapper(cfg => { }, typeof(MappingProfile).Assembly);

//Load Ioc
builder.Services
    .InfraLoadDependencyInjection();
builder.Services
    .AppLoadDependencyInjection();

builder.Services.AddCors(opt =>
{
    opt.AddPolicy(name: "DefaultCors", policy =>
    {
        policy.WithOrigins("http://localhost:5173/")
        .AllowAnyHeader()
        .AllowAnyMethod()
        .AllowAnyOrigin();
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseMiddleware<ExceptionMiddleware>();

app.UseHttpsRedirection();

app.UseCors("DefaultCors");

app.UseAuthorization();

app.MapControllers();

app.Run();
