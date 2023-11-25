using Microsoft.Extensions.Logging;
using MudBlazor;
using MudBlazor.Services;

namespace UniversalToolBox;

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

    	builder.Services.AddMudServices(config =>
	    {
		    config.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.TopCenter;

		    config.SnackbarConfiguration.PreventDuplicates = false;
		    config.SnackbarConfiguration.NewestOnTop = false;
		    config.SnackbarConfiguration.ShowCloseIcon = true;
		    config.SnackbarConfiguration.VisibleStateDuration = 10000;
		    config.SnackbarConfiguration.HideTransitionDuration = 500;
		    config.SnackbarConfiguration.ShowTransitionDuration = 500;
		    config.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
	    });
		builder.Services.AddMauiBlazorWebView();

#if DEBUG
		builder.Services.AddBlazorWebViewDeveloperTools();
		builder.Logging.AddDebug();
#endif
		return builder.Build();
	}
}
