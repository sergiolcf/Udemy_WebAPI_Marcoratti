using Api_Exec_2.DependencyInjection.Interface;
using Api_Exec_2.DependencyInjection.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

string mySqlConnection = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddSingleton<IDependencyInjection, DependencyInjection>();
var serviceProvider = builder.Services.BuildServiceProvider();
var dependencyInjectionService = serviceProvider.GetService<IDependencyInjection>();
dependencyInjectionService.RegisterServices(builder.Services, mySqlConnection);



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
