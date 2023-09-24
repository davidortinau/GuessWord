using Microsoft.Maui.Controls;

namespace GuessWord.Resources.Styles;

public static class AppColors
{
    
    public static ResourceDictionary GetResourceDictionary()
    {
        var rd = new ResourceDictionary();

        rd.Add("Primary", Color.FromArgb("#512BD4"));
        rd.Add("Secondary", Color.FromArgb("#DFD8F7"));
        rd.Add("Tertiary", Color.FromArgb("#2B0B98"));
        rd.Add("White", Colors.White);
        rd.Add("Black", Colors.Black);
        rd.Add("Gray100", Color.FromArgb("#E1E1E1"));
        rd.Add("Gray200", Color.FromArgb("#C8C8C8"));
        rd.Add("Gray300", Color.FromArgb("#ACACAC"));
        rd.Add("Gray400", Color.FromArgb("#919191"));
        rd.Add("Gray500", Color.FromArgb("#6E6E6E"));
        rd.Add("Gray600", Color.FromArgb("#404040"));
        rd.Add("Gray900", Color.FromArgb("#212121"));
        rd.Add("Gray950", Color.FromArgb("#141414"));
        rd.Add("PrimaryBrush", new SolidColorBrush(Color.FromArgb("#512BD4")));
        rd.Add("SecondaryBrush", new SolidColorBrush(Color.FromArgb("#DFD8F7")));
        rd.Add("TertiaryBrush", new SolidColorBrush(Color.FromArgb("#2B0B98")));
        rd.Add("WhiteBrush", new SolidColorBrush(Colors.White));
        rd.Add("BlackBrush", new SolidColorBrush(Colors.Black));
        rd.Add("Gray100Brush", new SolidColorBrush(Color.FromArgb("#E1E1E1")));
        rd.Add("Gray200Brush", new SolidColorBrush(Color.FromArgb("#C8C8C8")));
        rd.Add("Gray300Brush", new SolidColorBrush(Color.FromArgb("#ACACAC")));
        rd.Add("Gray400Brush", new SolidColorBrush(Color.FromArgb("#919191")));
        rd.Add("Gray500Brush", new SolidColorBrush(Color.FromArgb("#6E6E6E")));
        rd.Add("Gray600Brush", new SolidColorBrush(Color.FromArgb("#404040")));
        rd.Add("Gray900Brush", new SolidColorBrush(Color.FromArgb("#212121")));
        rd.Add("Gray950Brush", new SolidColorBrush(Color.FromArgb("#141414")));
        rd.Add("Yellow100Accent", Color.FromArgb("#F7B548"));
        rd.Add("Yellow200Accent", Color.FromArgb("#FFD590"));
        rd.Add("Yellow300Accent", Color.FromArgb("#FFE5B9"));
        rd.Add("Cyan100Accent", Color.FromArgb("#28C2D1"));
        rd.Add("Cyan200Accent", Color.FromArgb("#7BDDEF"));
        rd.Add("Cyan300Accent", Color.FromArgb("#C3F2F4"));
        rd.Add("Blue100Accent", Color.FromArgb("#3E8EED"));
        rd.Add("Blue200Accent", Color.FromArgb("#72ACF1"));
        rd.Add("Blue300Accent", Color.FromArgb("#A7CBF6"));

        return rd;
    }
}