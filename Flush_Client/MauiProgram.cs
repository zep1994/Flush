using Flush_Client.Pages;
using Flush_Client.DataServices;
using Flush_Client.Services;

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

            builder.Services.AddTransient<LoadingPage>();
            builder.Services.AddTransient<AuthService>();
            builder.Services.AddTransient<LoginPage>();
            builder.Services.AddSingleton<MainPage>();
            builder.Services.AddTransient<ManageIbsPage>();
            builder.Services.AddTransient<ProfilePage>();
            builder.Services.AddTransient<RegistrationPage>();
            builder.Services.AddTransient<IngredientPage>();

            return builder.Build();
        }
    }
}