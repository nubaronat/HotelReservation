using Business.Abstract;
using Business.Concrete;

using DataAccess;
using DataAccess.Abstract;

using Business;
using DataAccessLayer.Concrete;
using FluentValidation;
using Business.Validations.Customer;
using FluentValidation.AspNetCore;
using Entity.DTOs.Hotel;
using Entity.DTOs.Room;
using Entity.DTOs.Reservation;
using Entity.DTOs.Customer;



var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddFluentValidationAutoValidation();
builder.Services.AddFluentValidationClientsideAdapters();

builder.Services.AddValidatorsFromAssemblyContaining<CustomerCreateRequestDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<CustomerUpdateRequestDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<GetCustomerRequestDtoValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<HotelCreateRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<HotelUpdateRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<GetHotelRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<RoomCreateRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<RoomUpdateRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<GetRoomRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<ReservationCreateRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<ReservationUpdateRequestDto>();
builder.Services.AddValidatorsFromAssemblyContaining<GetReservationRequestDto>();

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
