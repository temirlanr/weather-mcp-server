using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WeatherMcpServer.Tools;
using WeatherMcpServer.Application;
using Microsoft.Extensions.Configuration;

var builder = Host.CreateApplicationBuilder(args);

// Configure all logs to go to stderr (stdout is used for the MCP protocol messages).
builder.Logging.AddConsole(o => o.LogToStandardErrorThreshold = LogLevel.Trace);
// Add application layer services.
builder.Services.AddApplicationServices();
// Add the configuration for the OpenWeather API key.
builder.Configuration.AddUserSecrets<Program>();
// Add the MCP services: the transport to use (stdio) and the tools to register.
builder.Services
    .AddMcpServer()
    .WithStdioServerTransport()
    .WithTools<RandomNumberTools>()
    .WithTools<WeatherTools>();

await builder.Build().RunAsync();