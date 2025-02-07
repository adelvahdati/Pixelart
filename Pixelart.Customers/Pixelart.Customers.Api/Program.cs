using Microsoft.EntityFrameworkCore;
using Pixelaret.Customers.Infrastructure.Data;
using Pixelaret.Customers.Infrastructure.Repositories;
using Pixelart.Customers.Services;
using Pixelart.Customers.Services.Intefraces;
using Pixelart.Customers.Services.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Pixelart-CustomersDb")));

builder.Services.AddScoped<ICustomerRepository,CustomerRepository>();
builder.Services.AddScoped<ICustomerService,CustomerService>();

builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.MapGet("/",() =>
{
    return "Welcome to Pixelart project customer microservice";
});
// app.UseHttpsRedirection();
app.MapControllers();


app.Run();
