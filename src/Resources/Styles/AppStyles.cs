using Microsoft.Maui.Controls;

namespace GuessWord.Resources.Styles
{
    public static class AppStyles
    {
        public static ResourceDictionary GetResourceDictionary()
        {
            var resourceDictionary = new ResourceDictionary();

            resourceDictionary.Add("Primary", Color.FromArgb("#0078D4"));
            resourceDictionary.Add("Secondary", Color.FromArgb("#6C757D"));
            resourceDictionary.Add("Gray200", Color.FromArgb("#EEEEEE"));
            resourceDictionary.Add("Gray300", Color.FromArgb("#E5E5E5"));
            resourceDictionary.Add("Gray400", Color.FromArgb("#9E9E9E"));
            resourceDictionary.Add("Gray500", Color.FromArgb("#616161"));
            resourceDictionary.Add("Gray600", Color.FromArgb("#424242"));
            resourceDictionary.Add("Gray900", Color.FromArgb("#212121"));
            resourceDictionary.Add("Gray950", Color.FromArgb("#141414"));
            resourceDictionary.Add("Black", Color.FromArgb("#000000"));
            resourceDictionary.Add("White", Color.FromArgb("#FFFFFF"));

            var commonStates = new VisualStateGroup();
            commonStates.Name = "CommonStates";

            var normalState = new VisualState();
            normalState.Name = "Normal";

            var disabledState = new VisualState();
            disabledState.Name = "Disabled";
            disabledState.Setters.Add(new Setter { Property = Switch.OnColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray300"], Dark = (Color)resourceDictionary["Gray600"] } });
            disabledState.Setters.Add(new Setter { Property = Switch.ThumbColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray300"], Dark = (Color)resourceDictionary["Gray600"] } });
            
            var onState = new VisualState();
            onState.Name = "On";
            onState.Setters.Add(new Setter { Property = Switch.OnColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Secondary"], Dark = (Color)resourceDictionary["Gray200"] } });
            onState.Setters.Add(new Setter { Property = Switch.ThumbColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Primary"], Dark = (Color)resourceDictionary["White"] } });
            
            var offState = new VisualState();
            offState.Name = "Off";
            offState.Setters.Add(new Setter { Property = Switch.ThumbColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray400"], Dark = (Color)resourceDictionary["Gray500"] } });

            commonStates.States.Add(normalState);
            commonStates.States.Add(disabledState);
            commonStates.States.Add(onState);
            commonStates.States.Add(offState);

            var switchStyle = new Style(typeof(Switch));
            switchStyle.Setters.Add(new Setter { Property = Switch.ThumbColorProperty, Value = new StaticResourceExtension { Key = "White" } });
            switchStyle.Setters.Add(new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = new VisualStateGroupList { commonStates } });

            var timePickerStyle = new Style(typeof(TimePicker));
            timePickerStyle.Setters.Add(new Setter { Property = TimePicker.TextColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray900"], Dark = (Color)resourceDictionary["White"] } });
            timePickerStyle.Setters.Add(new Setter { Property = TimePicker.BackgroundColorProperty, Value = Colors.Transparent });
            timePickerStyle.Setters.Add(new Setter { Property = TimePicker.FontFamilyProperty, Value = "OpenSansRegular" });
            timePickerStyle.Setters.Add(new Setter { Property = TimePicker.FontSizeProperty, Value = 14 });
            timePickerStyle.Setters.Add(new Setter { Property = TimePicker.MinimumHeightRequestProperty, Value = 44 });
            timePickerStyle.Setters.Add(new Setter { Property = TimePicker.MinimumWidthRequestProperty, Value = 44 });
            timePickerStyle.Setters.Add(new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = new VisualStateGroupList { commonStates } });

            var pageStyle = new Style(typeof(Page));
            pageStyle.Setters.Add(new Setter { Property = Page.PaddingProperty, Value = 0 });
            pageStyle.Setters.Add(new Setter { Property = Page.BackgroundColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["White"], Dark = (Color)resourceDictionary["Black"] } });

            var shellStyle = new Style(typeof(Shell));
            shellStyle.Setters.Add(new Setter { Property = Shell.BackgroundColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Primary"], Dark = (Color)resourceDictionary["Gray950"] } });
            shellStyle.Setters.Add(new Setter { Property = Shell.ForegroundColorProperty, Value = new OnPlatformExtension { WinUI = (Color)resourceDictionary["Primary"], Default = (Color)resourceDictionary["White"] } });
            shellStyle.Setters.Add(new Setter { Property = Shell.TitleColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["White"], Dark = (Color)resourceDictionary["White"] } });
            shellStyle.Setters.Add(new Setter { Property = Shell.DisabledColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray200"], Dark = (Color)resourceDictionary["Gray950"] } });
            shellStyle.Setters.Add(new Setter { Property = Shell.UnselectedColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray200"], Dark = (Color)resourceDictionary["Gray200"] } });
            shellStyle.Setters.Add(new Setter { Property = Shell.NavBarHasShadowProperty, Value = false });
            shellStyle.Setters.Add(new Setter { Property = Shell.TabBarBackgroundColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["White"], Dark = (Color)resourceDictionary["Black"] } });
            shellStyle.Setters.Add(new Setter { Property = Shell.TabBarForegroundColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Primary"], Dark = (Color)resourceDictionary["White"] } });
            shellStyle.Setters.Add(new Setter { Property = Shell.TabBarTitleColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Primary"], Dark = (Color)resourceDictionary["White"] } });
            shellStyle.Setters.Add(new Setter { Property = Shell.TabBarUnselectedColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray900"], Dark = (Color)resourceDictionary["Gray200"] } });

            var navigationPageStyle = new Style(typeof(NavigationPage));
            navigationPageStyle.Setters.Add(new Setter { Property = NavigationPage.BarBackgroundColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Primary"], Dark = (Color)resourceDictionary["Gray950"] } });
            navigationPageStyle.Setters.Add(new Setter { Property = NavigationPage.BarTextColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray200"], Dark = (Color)resourceDictionary["White"] } });
            navigationPageStyle.Setters.Add(new Setter { Property = NavigationPage.IconColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray200"], Dark = (Color)resourceDictionary["White"] } });

            var tabbedPageStyle = new Style(typeof(TabbedPage));
            tabbedPageStyle.Setters.Add(new Setter { Property = TabbedPage.BarBackgroundColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["White"], Dark = (Color)resourceDictionary["Gray950"] } });
            tabbedPageStyle.Setters.Add(new Setter { Property = TabbedPage.BarTextColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Primary"], Dark = (Color)resourceDictionary["White"] } });
            tabbedPageStyle.Setters.Add(new Setter { Property = TabbedPage.UnselectedTabColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray200"], Dark = (Color)resourceDictionary["Gray950"] } });
            tabbedPageStyle.Setters.Add(new Setter { Property = TabbedPage.SelectedTabColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray950"], Dark = (Color)resourceDictionary["Gray200"] } });

            
            var buttonStyle = new Style(typeof(Button));
            buttonStyle.Setters.Add(new Setter { Property = Button.TextColorProperty, Value = (Color)resourceDictionary["White"] });
            buttonStyle.Setters.Add(new Setter { Property = Button.BackgroundColorProperty, Value = (Color)resourceDictionary["Primary"] });
            buttonStyle.Setters.Add(new Setter { Property = Button.FontFamilyProperty, Value = "OpenSansRegular" });
            buttonStyle.Setters.Add(new Setter { Property = Button.FontSizeProperty, Value = 14 });
            buttonStyle.Setters.Add(new Setter { Property = Button.CornerRadiusProperty, Value = 8 });
            buttonStyle.Setters.Add(new Setter { Property = Button.PaddingProperty, Value = new Thickness(14, 10) });
            buttonStyle.Setters.Add(new Setter { Property = Button.MinimumHeightRequestProperty, Value = 44 });
            buttonStyle.Setters.Add(new Setter { Property = Button.MinimumWidthRequestProperty, Value = 44 });

            var visualStateGroupList = new VisualStateGroupList();
            var buttonCommonStates = new VisualStateGroup { Name = "CommonStates" };
            var buttonNormalState = new VisualState { Name = "Normal" };
            var buttonDisabledState = new VisualState { Name = "Disabled" };

            buttonDisabledState.Setters.Add(new Setter { Property = Button.TextColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray950"], Dark = (Color)resourceDictionary["Gray200"] } });
            buttonDisabledState.Setters.Add(new Setter { Property = Button.BackgroundColorProperty, Value = new AppThemeBindingExtension { Light = (Color)resourceDictionary["Gray200"], Dark = (Color)resourceDictionary["Gray600"] } });
            
            buttonCommonStates.States.Add(normalState);
            buttonCommonStates.States.Add(disabledState);
            visualStateGroupList.Add(commonStates);

            buttonStyle.Setters.Add(new Setter { Property = VisualStateManager.VisualStateGroupsProperty, Value = visualStateGroupList });
            resourceDictionary.Add(buttonStyle);

            resourceDictionary.Add(switchStyle);
            resourceDictionary.Add(timePickerStyle);
            resourceDictionary.Add(pageStyle);
            resourceDictionary.Add(shellStyle);
            resourceDictionary.Add(navigationPageStyle);
            resourceDictionary.Add(tabbedPageStyle);

            return resourceDictionary;
        }
    }
}
