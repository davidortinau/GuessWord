using Maui.FixesAndWorkarounds;

namespace GuessWord
{
	public class MainPage : ContentPage
	{
		private string word;
		private List<Label> letterLabels;

		private List<Label> missesLabels;
		private int incorrectGuesses;
		private const int MaxIncorrectGuesses = 6;

		public MainPage()
		{
			GetRandomWord();
			Build();	
			ListenForGuess();
		}

		void Build()
		{
			Grid grid = new Grid();
			HorizontalStackLayout stackLayout = new HorizontalStackLayout(){ Spacing = 18, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
			letterLabels = new List<Label>();
			for (int i = 0; i < word.Length; i++)
			{
				Label letterLabel = new Label
				{
					Text = "_",
					FontSize = 72,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				};
				letterLabels.Add(letterLabel);
				stackLayout.Children.Add(letterLabel);
			}

			grid.Add(stackLayout);
			HorizontalStackLayout misses = new(){
				Spacing = 18,
				HorizontalOptions = LayoutOptions.Center,
				VerticalOptions = LayoutOptions.End
			};
			
			missesLabels = new List<Label>();

			for (int i = 0; i < MaxIncorrectGuesses; i++)
			{
				Label letterLabel = new Label
				{
					Text = "X",
					FontSize = 36,
					TextColor = Colors.Red,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center,
					IsVisible = false
				};
				missesLabels.Add(letterLabel);
				misses.Children.Add(letterLabel);
			}
			grid.Add(misses);
			Content = grid;
		}

		void GetRandomWord()
		{
			word = WordList.GetRandomWord().ToUpper();
		}

		void DrawWord()
		{
			for (int i = 0; i < word.Length; i++)
			{
				letterLabels[i].Text = "_";
			}
		}

		async void ListenForGuess()
        {
			var kb = new KeyboardBehavior();
			this.Behaviors.Add(kb);
			// kb.Triggers.Add(new KeyboardBehaviorTrigger{ Keys = });

			kb.KeyUp += async (s, e)=>{
				Console.WriteLine($"KeyUp: {e.Keys.ToString()}");
				char letter = Char.ToUpper(e.KeyChar);
				if ((letter >= 'A' && letter <= 'Z'))
				{
					bool found = false;
					for (int i = 0; i < word.Length; i++)
					{
						if (Char.ToUpper(word[i]).Equals(letter))
						{
							letterLabels[i].Text = letter.ToString().ToUpper();
							found = true;

							string guess = string.Join("", letterLabels.Select(label => label.Text));
							if (guess == word)
							{
								var result = await DisplayAlert("Congratulations", "You guessed the word!", "Quit", "Play Again");
								HandleEndOfGame(result);
								return;
							}
						}
					}

					if (!found)
					{
						incorrectGuesses++;
						missesLabels[incorrectGuesses - 1].Text = letter.ToString().ToUpper();
						missesLabels[incorrectGuesses - 1].IsVisible = true;
						if (incorrectGuesses >= MaxIncorrectGuesses)
						{
							DrawWord();
							var result = await DisplayAlert("Game Over", $"The word was {word}.", "Quit", "Play Again");
							HandleEndOfGame(result);
						}
					}
				}
            };
        }

		void HandleEndOfGame(bool result)
		{
			if(!result)
			{
				Replay();
			}
			else
			{
				Environment.Exit(0);
			}
		}

		void Replay()
		{
			GetRandomWord();
			DrawWord();
			missesLabels.ForEach(label => label.IsVisible = false);
			incorrectGuesses = 0;
		}

		void OnLetterLabelFocused(object sender, FocusEventArgs e)
		{
			Label letterLabel = (Label)sender;
			int index = letterLabels.IndexOf(letterLabel);
			if (word.Contains(letterLabel.Text))
			{
				letterLabel.Text = word[index].ToString();
			}
			else
			{
				incorrectGuesses++;
				if (incorrectGuesses >= MaxIncorrectGuesses)
				{
					DisplayAlert("Game Over", $"The word was {word}.", "OK");
				}
			}
		}
	}
}