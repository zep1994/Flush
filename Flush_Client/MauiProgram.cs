using Flush_Client.Pages;
using Flush_Client.DataServices;

namespace Flush_Client
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
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            builder.Services.AddHttpClient<IRestDataService, RestDataService>();

            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ManageIbsPage>();

            return builder.Build();
        }
    }
}