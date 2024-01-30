using ProjetoArquitetura.API.Extensoes;

var builder = WebApplication.CreateBuilder(args);

Console.WriteLine($"Application Name: {builder.Environment.ApplicationName}");
Console.WriteLine($"Environment Name: {builder.Environment.EnvironmentName}");
Console.WriteLine($"ContentRoot Path: {builder.Environment.ContentRootPath}");
Console.WriteLine($"WebRootPath: {builder.Environment.WebRootPath}");


builder.Services.ConfigurarServicos();
builder.Services.ConfigurarJWT();
builder.Services.ConfigurarSwagger();

builder.Services.AddMemoryCache();
builder.Services.ConfigureRateLimitingOptions();


// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{

}
app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

//using Microsoft.AspNetCore;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.Extensions.Logging;
//using Microsoft.Extensions.Logging.EventLog;

//namespace ProjetoArquitetura.API.Controllers;

///// <summary>
///// Início da aplicaçao
///// </summary>
//public class Program
//{

//    /// <summary>
//    /// Constrói o programa inicial
//    /// </summary>
//    /// <param name="args"></param>
//    public static void Main(string[] args)
//    {
//        CreateWebHostBuilder(args).Build().Run();
//    }

//    /// <summary>
//    /// Cria o Host Web
//    /// </summary>
//    /// <param name="args"></param>
//    /// <returns></returns>
//    public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
//        WebHost.CreateDefaultBuilder(args)
//               .ConfigureLogging(logging =>
//               {
//                   logging.ClearProviders();
//                   logging.AddEventLog(new EventLogSettings() { Filter = (source, level) => level == LogLevel.Error });
//               })
//               .UseStartup<Startup>();
//}
