var builder = DistributedApplication.CreateBuilder(args);

var insights = builder.AddAzureApplicationInsights("applicationInsights");

var cache = builder.AddRedis("cache");

var apiService = builder.AddProject<Projects.AspireSample_ApiService>("apiservice")
    .WithReference(insights);

builder.AddProject<Projects.AspireSample_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(cache)
    .WithReference(apiService)
    .WithReference(insights);

builder.Build().Run();
