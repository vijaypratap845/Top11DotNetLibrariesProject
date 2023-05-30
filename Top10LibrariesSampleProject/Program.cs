using FluentValidation;
using Microsoft.OpenApi.Models;
using System.Reflection;
using Top10LibrariesSampleProject.DAL;
using Top10LibrariesSampleProject.DAL.Context;
using Top10LibrariesSampleProject.DAL.Interfaces;
using Top10LibrariesSampleProject.DAL.Logger;
using Top10LibrariesSampleProject.Model;
using Top10LibrariesSampleProject.Validator;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Sample API Docs",
        Version = "v1"
    });
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please insert JWT with Bearer into field",
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement {
                {
                    new OpenApiSecurityScheme {
                        Reference = new OpenApiReference {
                            Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                        }
                    },
                    new string[] {}
                }
                 });
    options.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, $"{Assembly.GetExecutingAssembly().GetName().Name}.xml"));
    //options.OperationFilter<AddRequiredHeaderParameter>();
});

builder.Services.AddSingleton<ILoggerService, LoggerService>();
builder.Services.AddSingleton<DapperContext>();
builder.Services.AddScoped<IProduct, ProductRepo>();
///builder.Services.AddTransient<IValidator<AddUpdateProduct>>(c => new ProductValidator());
builder.Services.AddMiniProfiler(options => options.RouteBasePath = "/profiler");
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();
app.UseMiniProfiler();
app.MapControllers();

app.Run();
