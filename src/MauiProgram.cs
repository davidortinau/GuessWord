using Maui.FixesAndWorkarounds;
using Microsoft.Extensions.Logging;
using Microsoft.Maui.Handlers;

namespace GuessWord;

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

#if DEBUG
		builder.Logging.AddDebug();
#endif
		builder.ConfigureMauiHandlers(handlers =>
		{
			#if IOS || MACCATALYST
				PageHandler.PlatformViewFactory = (handler) =>
				{
					var vc = new KeyboardPageViewController(handler.VirtualView, handler.MauiContext);
					handler.ViewController = vc;
					return (Microsoft.Maui.Platform.ContentView)vc.View.Subviews[0];
				};
#endif
		});

		return builder.Build();
	}
}
