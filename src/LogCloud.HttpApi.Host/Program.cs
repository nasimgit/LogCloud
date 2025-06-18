using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;
using Serilog.Sinks.GoogleCloudLogging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace LogCloud;

public class Program
{
    public async static Task<int> Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateBootstrapLogger();

        try
        {
            Log.Information("Starting LogCloud.HttpApi.Host.");
            var builder = WebApplication.CreateBuilder(args);
            //builder.Host
            //    .AddAppSettingsSecretsJson()
            //    .UseAutofac()
            //    .UseSerilog((context, services, loggerConfiguration) =>
            //    {
            //        loggerConfiguration
            //        #if DEBUG
            //            .MinimumLevel.Debug()
            //        #else
            //            .MinimumLevel.Information()
            //        #endif
            //            .MinimumLevel.Override("Microsoft", LogEventLevel.Information)
            //            .MinimumLevel.Override("Microsoft.EntityFrameworkCore", LogEventLevel.Warning)
            //            .Enrich.FromLogContext()
            //            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            //            .WriteTo.Async(c => c.Console())
            //            .WriteTo.Async(c => c.AbpStudio(services));
            //    });


            // serilog config programmatically
            {
                var options = new GoogleCloudLoggingSinkOptions
                {
                    ProjectId = "My Project 80810",
                    ResourceType = "gce_instance",
                    LogName = "someLogName",
                    UseSourceContextAsLogName = true,
                };

                builder.Host.UseSerilog((ctx, lc) => lc.WriteTo.Console().WriteTo.GoogleCloudLogging(options).MinimumLevel.Is(LogEventLevel.Verbose));
            }

            await builder.AddApplicationAsync<LogCloudHttpApiHostModule>();
            var app = builder.Build();
            app.UseSerilogRequestLogging();
            app.MapGet("/", ([FromServices] Microsoft.Extensions.Logging.ILogger<Program> _logger, [FromServices] ILoggerFactory _loggerFactory) =>
            {
                Log.Information("Test info message with serilog");
                Log.Debug("Test debug message with serilog");

                _logger.LogInformation("Test info message with ILogger abstraction");
                _logger.LogDebug("Test debug message with ILogger abstraction");

                // ASP.NET Logger Factory accepts custom log names but these must follow the rules for Google Cloud logging:
                // https://cloud.google.com/logging/docs/reference/v2/rest/v2/LogEntry
                // Names must only include upper and lower case alphanumeric characters, forward-slash, underscore, hyphen, and period. No spaces!
                var anotherLogger = _loggerFactory.CreateLogger("AnotherLogger");
                anotherLogger.LogInformation("Test message with ILoggerFactory abstraction and custom log name");

                _logger.LogInformation(eventId: new Random().Next(), message: "Test message with random event ID");
                _logger.LogInformation("Test message with List<string> {list}", new List<string> { "foo", "bar", "pizza" });
                _logger.LogInformation("Test message with List<int> {list}", new List<int> { 123, 456, 7890 });
                _logger.LogInformation("Test message with Dictionary<string,object> {dict}", new Dictionary<string, object>
            {
                { "valueAsNull", null },
                { "valueAsBool", true },
                { "valueAsString", "qwerty" },
                { "valueAsStringNumber", "00000" },
                { "valueAsMaxInt", int.MaxValue },
                { "valueAsMaxLong", long.MaxValue },
                { "valueAsDouble", 123.456 },
                { "valueAsMaxDouble", double.MaxValue },
                { "valueAsMaxDecimal", decimal.MaxValue },
            });

                try
                {
                    throw new Exception("Testing exception logging");
                }
                catch (Exception e)
                {
                    _logger.LogError(e, "");
                }

                var url = $"https://console.cloud.google.com/logs/viewer";
                var html = $"<html><body>Logged messages at {DateTime.UtcNow:O}, visit GCP log viewer at <a href='{url}' target='_blank'>{url}</a></body></html>";

                return Results.Content(html, "text/html");
            });

            await app.InitializeApplicationAsync();
            await app.RunAsync();
            return 0;
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
            return 1;
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
