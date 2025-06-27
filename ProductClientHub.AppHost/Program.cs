var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.ProductClientHub_ApiService>("apiservice");

builder.AddProject<Projects.ProductClientHub_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
