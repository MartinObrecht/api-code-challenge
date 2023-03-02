using codeChallenge.Core.Extensions;
using codeChallenge.Core.Middlewares;
using codeChallenge.Data;
using codeChallenge.Data.Repositories;
using codeChallenge.Domain.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Serilog;

try
{
    var builder = WebApplication.CreateBuilder(args);
    SerilogExtensions.AddSerilogApi(builder.Configuration);
    builder.Host.UseSerilog(Log.Logger);

    // Add services to the container.

    builder.Services.AddControllers();
    // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    builder.Services.AddDbContext<CodeChallengeContext>(options =>
    {
        options.UseSqlServer(builder.Configuration.GetConnectionString("defaultConnection"));
    });

    builder.Services.AddRepositories();
    builder.Services.AddMediatRApi();

    var app = builder.Build();

    using (var serviceScope = app.Services.CreateAsyncScope())
    {
        serviceScope.ServiceProvider.GetService<CodeChallengeContext>().Database.Migrate();
    }

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseMiddleware<ErrorHandlingMiddleware>();
    app.UseMiddleware<RequestSerilLogMiddleware>();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();

}
catch (Exception ex)
{
    Log.Fatal(ex, "Host terminated unexpectedly");
}
finally
{
    Log.Information("Server Shutting down...");
    Log.CloseAndFlush();
}
