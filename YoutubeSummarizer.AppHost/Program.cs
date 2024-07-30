using Microsoft.Extensions.Configuration;

var builder = DistributedApplication.CreateBuilder(args);

var config = builder.Configuration;

Console.WriteLine($"\n Aspire Start, Launch Type: {config["LaunchType"]}\n");

builder.Build().Run();