
using myProject.Components.Data;
using myProject.Components.Interfaces;
using myProject.Components.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace myProject
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                });

            builder.Services.AddMauiBlazorWebView();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
            builder.Logging.AddDebug();
#endif

            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "myProject.db");

            builder.Services.AddDbContext<AppDbContext>(options =>
                options.UseSqlite($"Data Source={dbPath}"),
                ServiceLifetime.Scoped);

            builder.Services.AddScoped<IExpenseService, ExpenseService>();

            var app = builder.Build();

            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
            }

            return app;
        }
    }
}
