﻿using GuessWord.Resources.Styles;

namespace GuessWord;

public class App : Application
{
	public App()
	{
		// load resources
		Resources.MergedDictionaries.Add(AppColors.GetResourceDictionary());
		Resources.MergedDictionaries.Add(AppStyles.GetResourceDictionary());

		App.Current.UserAppTheme = AppTheme.Light;

		MainPage = new MainPage();
	}
}
