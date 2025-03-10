using AspireSample.ApiService.Weather;
using AspireSample.Database;
using Microsoft.EntityFrameworkCore;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);
builder.AddSqlServerDbContext<WeatherContext>("sqldata");
builder.AddRedisClient("cache");

// Add service defaults & Aspire components.
builder.AddServiceDefaults();

// Add services to the container.
builder.Services.AddProblemDetails();

builder.Services.AddDbContext<WeatherContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("sqldata"), sqlOptions =>
    {
        // sqlOptions.MigrationsAssembly("DatabaseMigrations.MigrationService");
        // Workaround for https://github.com/dotnet/aspire/issues/1023
        sqlOptions.ExecutionStrategy(c => new RetryingSqlServerRetryingExecutionStrategy(c));
    }));

builder.Services.AddTransient<IWeatherService, WeatherService>();
builder.Services.AddTransient<WeatherDatabaseRepository>();

builder.Services.AddTransient<IWeatherRepository>(x => new WeatherCachedRepository(
    x.GetRequiredService<WeatherDatabaseRepository>(),
    x.GetRequiredService<IConnectionMultiplexer>())
);

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    // using (var scope = app.Services.CreateScope())
    // {
    //     var context = scope.ServiceProvider.GetRequiredService<WeatherContext>();
    //     context.Database.EnsureCreated();
    // }
}
else
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    // The default HSTS value is 30 days.
    // You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

// Configure the HTTP request pipeline.
app.UseExceptionHandler();

app.MapWeatherEndpoint();
app.MapDefaultEndpoints();

app.Run();
