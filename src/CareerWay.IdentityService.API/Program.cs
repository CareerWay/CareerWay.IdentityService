using CareerWay.Shared.AspNetCore.Logging.Extensions;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);
builder.Services.AddWebServices(builder.Configuration, builder.Host);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    await app.InitializeDatabaseAsync();
}

app.UseEnableRequestBuffering();

app.UseRequestTime();

app.UseCorrelationId();

app.UseHttpsRedirection();

app.MapOpenApi();

app.MapScalarApiReference(options =>
{
    options.Title = "JobAdvertService Open API";
    options.OperationSorter = OperationSorter.Method;
});

app.UsePushSerilogProperties();

app.UseCustomHttpLogging();

app.MapControllers();

app.UseExceptionHandler(o => { });

app.Run();
