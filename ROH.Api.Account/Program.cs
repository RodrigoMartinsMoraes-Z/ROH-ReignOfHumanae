using AutoMapper;

using FluentValidation;

using ROH.Context.PostgreSQLContext;
using ROH.Interfaces;
using ROH.Interfaces.Repository.Account;
using ROH.Interfaces.Repository.Log;
using ROH.Interfaces.Services.Account;
using ROH.Interfaces.Services.ExceptionService;
using ROH.Repository.Account;
using ROH.Repository.Log;
using ROH.Services.Account;
using ROH.Services.ExceptionService;
using ROH.StandardModels.Account;
using ROH.Validations.Account;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Registry Interfaces
builder.Services.AddScoped<ISqlContext, SqlContext>();
builder.Services.AddScoped<ILogRepository, LogRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IValidator<UserModel>, UserModelValidation>();

builder.Services.AddScoped<IExceptionHandler, ExceptionHandler>();

// Auto Mapper Configurations
MapperConfiguration mappingConfig = new(mc =>
{

});

IMapper mapper = mappingConfig.CreateMapper();
builder.Services.AddSingleton(mapper);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapPost("CreateNewUser", async (IUserService _userService, UserModel model) =>
    await _userService.NewUser(model)
).WithName("CreateNewUser")
.WithOpenApi();

app.UseHttpsRedirection();

app.Run();

