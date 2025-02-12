using eAppointmentServer.Application;
using eAppointmentServer.Domain;
using eAppointmentServer.Domain.Entities;
using eAppointmentServer.Infrastructure;
using eAppointmentService.API;
using Microsoft.AspNetCore.Identity;


var builder = WebApplication.CreateBuilder(args);
builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);
// Add services to the container.
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
app.UseCors(options =>
     options.WithOrigins("http://localhost:4200")
            .AllowAnyHeader()
            .AllowAnyMethod());

app.UseAuthorization();

app.MapControllers();

Helper.CreateUser(app).Wait();

app.Run();
