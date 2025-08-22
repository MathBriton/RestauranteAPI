using Microsoft.EntityFrameworkCore;
using RestauranteAPI.Application.Interfaces;
using RestauranteAPI.Application.Services;
using RestauranteAPI.Domain.Repositories;
using RestauranteAPI.Infrastructure.Context;
using RestauranteAPI.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// ===== EF Core =====
builder.Services.AddDbContext<RestauranteContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// ===== Repositórios =====
builder.Services.AddScoped<ITableRepository, TableRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();

// ===== Serviços / Cases de uso =====
builder.Services.AddScoped<ITableService, TableService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IOrderService, OrderService>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();


// ===== Endpoints: Mesas =====
app.MapGet("/tables", async (ITableService service) =>
{
    var tables = await service.GetAllTablesAsync();
    return Results.Ok(tables);
});

app.MapPost("/tables", async (int number, ITableService service) =>
{
    var table = await service.OpenTableAsync(number);
    return Results.Created($"/tables/{table.Id}", table);
});

app.MapPut("/tables/{id}/close", async (int id, ITableService service) =>
{
    await service.CloseTableAsync(id);
    return Results.NoContent();
});


// ===== Endpoints: Produtos =====
app.MapGet("/products", async (IProductService service) =>
{
    var products = await service.GetAllProductsAsync();
    return Results.Ok(products);
});

app.MapPost("/products", async (string name, decimal price, IProductService service) =>
{
    var product = await service.CreateProductAsync(name, price);
    return Results.Created($"/products/{product.Id}", product);
});

app.MapPut("/products/{id}", async (int id, string name, decimal price, IProductService service) =>
{
    await service.UpdateProductAsync(id, name, price);
    return Results.NoContent();
});


// ===== Endpoints: Pedidos =====
app.MapGet("/orders", async (IOrderService service) =>
{
    var orders = await service.GetAllOrderAsync();
    return Results.Ok(orders);
});

app.MapPost("/orders", async (int tableId, IOrderService service) =>
{
    var order = await service.CreateOrderAsync(tableId);
    return Results.Created($"/orders/{order.Id}", order);
});

app.MapPost("/orders/{orderId}/items", async (int orderId, int productId, int quantity, IOrderService service) =>
{
    await service.AddItemToOrderAsync(orderId, productId, quantity);
    return Results.NoContent();
});

app.MapPut("/orders/{orderId}/close", async (int orderId, IOrderService service) =>
{
    await service.CloseOrderAsync(orderId);
    return Results.NoContent();
});

app.Run();
