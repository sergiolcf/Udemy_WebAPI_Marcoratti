using ApiExecUm.DependencyInjection;
using ApiExecUm.DependencyInjection.Interface;


var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IDependencyInjection, DependencyInjection>();

var mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");
var serviceProvider = builder.Services.BuildServiceProvider();
var dependencyInjection = serviceProvider.GetService<IDependencyInjection>();
dependencyInjection.RegisterServices(builder.Services, mySqlConnection);



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