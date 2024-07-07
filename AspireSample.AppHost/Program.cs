var builder = DistributedApplication.CreateBuilder(args);

var insights = builder.AddAzureApplicationInsights("applicationInsights");

var cache = builder
    .AddRedis("cache")
    .WithRedisCommander();

var sql = builder.AddSqlServer("sql")
    .AddDatabase("sqldata");

builder.AddProject<Projects.AspireSample_Database>("migration")
    .WithReference(sql);

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithReference(cache)
    .WithReference(sql)
    .WithReference(insights);

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService)
    .WithReference(insights);

builder.Build().Run();
