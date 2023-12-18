using BP.Api.Extensions;
using BP.Api.Validations;
using BP.APÝ.Service;
using BP.Models;
using FluentValidation;
using FluentValidation.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Configuration.SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false)
    .AddJsonFile("appsettings.development.json", optional: false)
    .AddEnvironmentVariables()
    .Build();

builder.Services.AddControllers()
    //.AddFluentValidation(i => i.RunDefaultMvcValidationAfterFluentValidationExecutes=false);
    .AddFluentValidation();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddHealthChecks();

builder.Services.ConfigureMapping();

builder.Services.AddScoped<IContactService, ContactManager>();

builder.Services.AddTransient<IValidator<ContactDVO>, ContactValidator>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCustomHealthCheck();

app.UseResponseCaching();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
