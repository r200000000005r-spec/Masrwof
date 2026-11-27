using Masrwof.Components.Data;
using Masrwof.Components.Interfaces;
using Masrwof.Components.Services;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Radzen;
namespace Masrwof
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
            builder.Services.AddRadzenComponents();

#if DEBUG
            builder.Services.AddBlazorWebViewDeveloperTools();
    		builder.Logging.AddDebug();
#endif
            string dbPath = Path.Combine(FileSystem.AppDataDirectory, "Masrwof.db");
            builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlite($"Data Source={dbPath}"),ServiceLifetime.Scoped);
            builder.Services.AddScoped<IExpenseService, ExpenseService>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            var app = builder.Build();
            using (var scope =app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<AppDbContext>();
                context.Database.EnsureCreated();
            }
            return app;
        }
    }
}
