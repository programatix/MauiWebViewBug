using MauiWebViewBug.Control;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Controls.Compatibility.Hosting;

namespace MauiWebViewBug;

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
            })
            .ConfigureMauiHandlers(handlers =>
            {
#if ANDROID
                handlers.AddHandler(typeof(MyWebView), typeof(Platforms.Android.Handlers.MyWebViewHandler));
#endif
#if IOS
                handlers.AddHandler(typeof(MyWebView), typeof(Platforms.iOS.Handlers.MyWebViewHandler));
#endif
            });

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}