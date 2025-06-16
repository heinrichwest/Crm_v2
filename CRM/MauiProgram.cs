using CRM.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;


public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();

        builder
            .UseMauiApp<CRM.App>()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
            });

        builder.Services.AddMauiBlazorWebView();

        // Define your connection string
        var connectionString = "server=localhost;database=your_db_name;user=your_user;password=Zuluzaan1!;";

        // Add DbContext with MySQL
        builder.Services.AddDbContext<AppDbContext>(options =>
            options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString)));

        // Register your application services
        builder.Services.AddScoped<CRM.Services.ClientService>();
        builder.Services.AddScoped<CRM.Services.UserService>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
