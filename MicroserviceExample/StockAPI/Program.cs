using MassTransit;
using MongoDB.Driver;
using Shared;
using StockAPI.Consumers;
using StockAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddMassTransit(configurator =>
{
    configurator.AddConsumer<OrderCreatedEventConsumer>();

    configurator.UsingRabbitMq((context, _configurator) =>
    {
        _configurator.Host(builder.Configuration["RabbitMQ"]);

        _configurator.ReceiveEndpoint(RabbitMQSettings.Stock_OrderCreatedEventQueue, e => e.ConfigureConsumer<OrderCreatedEventConsumer>(context));
    });
});

builder.Services.AddSingleton<MongoDbService>();

//seed data
using IServiceScope scope = builder.Services.BuildServiceProvider().CreateScope();
MongoDbService mongoDBService = scope.ServiceProvider.GetService<MongoDbService>();
var collection = mongoDBService.GetCollection<StockAPI.Models.Entities.Stock>();
if(!collection.FindSync(s=>true).Any())
{
    await collection.InsertOneAsync(new() { ProductId = Guid.NewGuid(), Count = 1000 });
    await collection.InsertOneAsync(new() { ProductId = Guid.NewGuid(), Count = 2000 });
    await collection.InsertOneAsync(new() { ProductId = Guid.NewGuid(), Count = 3000 });
    await collection.InsertOneAsync(new() { ProductId = Guid.NewGuid(), Count = 4000 });
    await collection.InsertOneAsync(new() { ProductId = Guid.NewGuid(), Count = 5000 });
}

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
