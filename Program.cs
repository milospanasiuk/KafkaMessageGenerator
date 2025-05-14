using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OrderKafkaMessageGenerator;
using OrderKafkaMessageGenerator.ConfigurationOptions;
using OrderKafkaMessageGenerator.Converters;
using System;
using System.IO;
using System.Reflection;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var basePath = AppContext.BaseDirectory;
var assemblyName = typeof(Program).GetTypeInfo().Assembly.GetName().Name;

// Add services to the container.
builder.Services.Configure<AppSettings>(
    builder.Configuration.GetSection("AppSettings")
);

builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.PropertyNamingPolicy = null;
        options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
        options.JsonSerializerOptions.WriteIndented = true;

        options.JsonSerializerOptions.Converters.Add(new UtcDateTimeOffsetConverter());
    });

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = $"Order Kafka Message Generator API", Version = "v1" });
    options.UseInlineDefinitionsForEnums();

    try
    {
        var fileName = $"{assemblyName}.xml";
        var xmlCommentsFilePath = Path.Combine(basePath, fileName);

        if (File.Exists(xmlCommentsFilePath))
        {
            options.IncludeXmlComments(xmlCommentsFilePath, true);
        }
    }
    catch
    {

    }
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin", builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.RegisterServices(builder.Configuration);

var app = builder.Build();

app.UseSwagger(c =>
{
    c.RouteTemplate = "generatorapi/{documentName}/swagger.json";
});

app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/generatorapi/v1/swagger.json", "Order Kafka Message Generator API");
    c.RoutePrefix = "generatorapi/swagger";
});

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
