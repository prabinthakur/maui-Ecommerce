using Microsoft.AspNetCore.Components;
using Microsoft.Extensions.Logging;
using MudBlazor.Services;
using Second.Service;


namespace Second
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
            builder.Services.AddSingleton<UserService>();
            builder.Services.AddSingleton<ProductService>();
            builder.Services.AddSingleton<OrderService>();
            builder.Services.AddSingleton<MembershipService>();
            builder.Services.AddMudServices();
            return builder.Build();
        }
    }
}
