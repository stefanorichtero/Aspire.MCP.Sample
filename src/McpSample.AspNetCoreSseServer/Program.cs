using ModelContextProtocol;
using AspNetCoreSseServer;

var builder = WebApplication.CreateBuilder(args);

// Add default services
builder.AddServiceDefaults();
builder.Services.AddProblemDetails();

// add MCP server
builder.Services.AddMcpServer().WithTools();
var app = builder.Build();

// Initialize default endpoints
app.MapDefaultEndpoints();

// map endpoints
app.MapGet("/", () => $"Hello World! {DateTime.Now}");
app.MapMcpSse();

app.Run();
