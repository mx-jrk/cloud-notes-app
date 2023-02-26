namespace Cloud_Notes_App;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("DexaRound-Regular.ttf", "DRR");
				fonts.AddFont("DexaRound-SemiBold.ttf", "DRS");
			});

		return builder.Build();
	}
}
