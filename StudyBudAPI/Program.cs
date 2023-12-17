using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using StudyBudAPI;
using StudyBudAPI.Entities;
using StudyBudAPI.Models;
using StudyBudAPI.Models.Validator;
using StudyBudAPI.Services;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddFluentValidation();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<StudyBudDbContext>
	(options => options.UseSqlServer(builder.Configuration.GetConnectionString("StudyBudConnection")));
builder.Services.AddScoped<StudyBudSeeder>();
builder.Services.AddScoped<IValidator<CreateTopicDto>, CreateTopicDtoValidator>();
builder.Services.AddScoped<IValidator<StudyBudQuery>, StudyBudQueryValidator>();
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.AddScoped<ITopicService, TopicService>();
builder.Services.AddScoped<IRoomService, RoomService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
var scope = app.Services.CreateScope();
var seeder = scope.ServiceProvider.GetRequiredService<StudyBudSeeder>();

seeder.Seed();

if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
