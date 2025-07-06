using Tourism.Application;
using Tourism.Presentation.Api.Middleware;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.AddApplication();
builder.Services.AddSwaggerGen(options =>
{
    options.EnableAnnotations(); // Enable support for SwaggerOperation
});
// Add CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        var cors =
            builder.Configuration.GetSection("ApiCors").Get<string[]>() ?? new string[0] { };
        policy
            .WithOrigins(cors)
            .SetIsOriginAllowedToAllowWildcardSubdomains()
            .AllowAnyHeader()
            .AllowAnyMethod()
            .AllowCredentials();
    });
});

var app = builder.Build();
app.Services.RunMigrations();
// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();
app.Use(ApiMiddleware.HandleException);

app.MapControllers();

app.Run();