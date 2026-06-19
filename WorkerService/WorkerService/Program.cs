using WorkerService;

var builder = Host.CreateApplicationBuilder(args);
builder.Services.AddHostedService<FileWathcerService>();
builder.Services.AddHostedService<LogArchiveService>();

var host = builder.Build();
host.Run();
