using RabitMqProductAPI.Data;
using RabitMqProductAPI.RabbitMQ;
using RabitMqProductAPI.Services;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<DbContextClass>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IRabitMQProduct, RabitMQProduct>();
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();
