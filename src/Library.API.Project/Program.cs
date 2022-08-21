using Library.API.Data;
using Library.API.Interfaces.Repository;
using Library.API.Interfaces.Service;
using Library.API.Repository;
using Library.API.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<LibraryAPIContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("LibraryAPIContext") ?? throw new InvalidOperationException("Connection string 'LibraryAPIContext' not found.")));

// Add services to the container.
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAllOrigins", config =>
         config.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader()
               .Build()
    );
});

builder.Services.AddSwaggerGen(c =>
{
    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });
    c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type= ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }

                });
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Library_API", Version = "v1" });

});

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IBookService, BookService>();

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
