using Library.API.Project.ConfigStartApp;
using Library.API.Project.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LibraryAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryAPIContext") ?? throw new InvalidOperationException("Connection string 'LibraryAPIContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

ConfigurationProgram.ConfigureCors(builder.Services);
ConfigurationProgram.ConfigureDependencyInjection(builder.Services);
ConfigurationProgram.ConfigureSwagger(builder.Services);

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

app.UseCors();

app.Run();
