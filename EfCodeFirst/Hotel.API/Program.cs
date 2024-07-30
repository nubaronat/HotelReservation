using Business.Abstract;
using Business.Concrete;

using DataAccess;
using DataAccess.Abstract;

using Business;
using DataAccessLayer.Concrete;
using FluentValidation.AspNetCore;
using Business.Validations.Room;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();
builder.Services.AddValidatorsFromAssemblyContaining<RoomCreateRequestDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetRoomRequestDtoValidator>();







// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<Context>();

builder.Services.AddPersistenceServices();


builder.Services.AddingBusinessServices();



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
