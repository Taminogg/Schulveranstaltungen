using Core.Backend;
using Core.Plugin.Interface;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using SYP_Schulveranstaltungen.Services;

namespace CorePlugin.Plugin;

public class Plugin : ICorePlugin
{
    public void ConfigureServices(WebApplicationBuilder builder)
    {
        string? connectionString = builder.Configuration.GetConnectionString("ExcursionsDbSqlite")!;
        string location = System.Reflection.Assembly.GetEntryAssembly()!.Location;
        string dataDirectory = Path.GetDirectoryName(location)!;
        connectionString = connectionString?.Replace("|DataDirectory|", dataDirectory + Path.DirectorySeparatorChar);
        //Console.WriteLine($"******** ConnectionString: {connectionString}");
        builder.Services.AddDbContext<ExcursionContext>(options => options.UseSqlite(connectionString));

        builder.Services.AddHostedService<DbAssertionService>();
        builder.Services.AddScoped<DbService>();

        builder.Services.AddControllers();
    }

    public void Configure(WebApplication app)
    {
        //TODO: Eventually add your own middleware here (e.g. SignalR, etc.)
        app.MapControllers();
    }
}
