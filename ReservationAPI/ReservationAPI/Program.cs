using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReservationAPI.Application.UseCases;
using ReservationAPI.Domain.Interfaces;
using ReservationAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Register repositories
builder.Services.AddScoped<IServiceRepository, ServiceRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();

// Register use cases
builder.Services.AddScoped<GetServicesUseCase>();
builder.Services.AddScoped<CreateReservationUseCase>();
builder.Services.AddScoped<GetReservationUseCase>();
builder.Services.AddScoped<GetReservationHoursEnables>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
//builder.Services.AddSwaggerGen();

// Add CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowReactApp",
        builder =>
        {
            builder
                .WithOrigins("http://localhost:3000")
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
                
        });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    //app.UseSwagger();
    //app.UseSwaggerUI();
}

// IMPORTANT: UseCors must be called before UseAuthorization and UseEndpoints
app.UseCors("AllowReactApp");
//app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();