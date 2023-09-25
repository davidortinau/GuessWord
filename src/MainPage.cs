using Maui.FixesAndWorkarounds;

namespace GuessWord
{
	public class MainPage : ContentPage
	{
		private string puzzle;
		private List<Label> letterLabels;

		private List<Label> missesLabels;
		private int incorrectGuesses;
        private HorizontalStackLayout puzzleLayout;
        private List<char> guessedLetters;
        private const int MaxIncorrectGuesses = 6;

		public MainPage()
		{
			Build();	
			Replay();
			ListenForGuess();
			InitMenu();
		}

		void InitMenu()
		{
			MenuBarItem appMenu = new(){
				Text = "App"
			};

			appMenu.Add(new MenuFlyoutItem{
				Text = "Reset",
				Command = new Command(()=>{ Replay(); })
			});

			appMenu.Add(new MenuFlyoutItem{
				Text = "Quit", 
				Command = new Command(()=>{ Environment.Exit(0); })
			});
			
			this.MenuBarItems.Add(appMenu);
		}

		void Build()
		{
			Grid grid = new Grid(){
				Margin = new Thickness(20)
			};
			puzzleLayout = new HorizontalStackLayout(){ Spacing = 18, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };
			grid.Add(puzzleLayout);

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
					Text = " ",
					FontSize = 36,
					WidthRequest = 60,
					HeightRequest = 80,
					VerticalTextAlignment = TextAlignment.Center,
					HorizontalTextAlignment = TextAlignment.Center,
					Padding = new Thickness(6, 4, 6, 4),
					BackgroundColor = Color.FromArgb("#F1F1F1"),
					TextColor = Colors.White,
					HorizontalOptions = LayoutOptions.Center,
					VerticalOptions = LayoutOptions.Center
				};
				missesLabels.Add(letterLabel);
				misses.Children.Add(letterLabel);
			}
			grid.Add(misses);

			Button btn = new(){
				Text = "Reset",
				BackgroundColor = Color.FromArgb("#1d1d1d"),
				TextColor = Colors.White,
				HorizontalOptions = LayoutOptions.End,
				VerticalOptions = LayoutOptions.End
			};

			btn.Clicked += (s, e) => Replay();
			grid.Add(btn);

			Content = grid;
		}

		void GetRandomPuzzle()
		{
			puzzle = PuzzleList.GetRandomPuzzle().ToUpper();
		}

		void DrawWord()
		{
			guessedLetters = new List<char>();
			letterLabels = new List<Label>();
			for (int i = 0; i < puzzle.Length; i++)
			{
				if(puzzle[i] != ' ')
				{				
					Label letterLabel = new Label
					{
						Text = "_",
						FontSize = 72,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center
					};
					letterLabels.Add(letterLabel);
					puzzleLayout.Children.Add(letterLabel);
				}else{
					Label spaceLabel = new Label
					{
						Text = " ",
						FontSize = 72,
						HorizontalOptions = LayoutOptions.Center,
						VerticalOptions = LayoutOptions.Center
					};
					letterLabels.Add(spaceLabel);
					puzzleLayout.Children.Add(spaceLabel);
				}
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
					if (!guessedLetters.Contains(letter))
					{
						guessedLetters.Add(letter);

						bool found = false;
						for (int i = 0; i < puzzle.Length; i++)
						{
							if (Char.ToUpper(puzzle[i]).Equals(letter))
							{
								letterLabels[i].Text = letter.ToString().ToUpper();
								found = true;

								string guess = string.Join("", letterLabels.Select(label => label.Text));
								if (guess == puzzle)
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
							missesLabels[incorrectGuesses - 1].BackgroundColor = Color.FromArgb("#CC0000");
							if (incorrectGuesses >= MaxIncorrectGuesses)
							{
								var result = await DisplayAlert("Game Over", $"The word was {puzzle}.", "Quit", "Play Again");
								HandleEndOfGame(result);
							}
						
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
			guessedLetters = new List<char>();
			puzzleLayout.Children.Clear();
			letterLabels = new List<Label>();
			GetRandomPuzzle();
			DrawWord();
			missesLabels.ForEach(label => {
				label.BackgroundColor = Color.FromArgb("#F1F1F1");
				label.Text = " ";
			});
			incorrectGuesses = 0;
		}

		void OnLetterLabelFocused(object sender, FocusEventArgs e)
		{
			Label letterLabel = (Label)sender;
			int index = letterLabels.IndexOf(letterLabel);
			if (puzzle.Contains(letterLabel.Text))
			{
				letterLabel.Text = puzzle[index].ToString();
			}
			else
			{
				incorrectGuesses++;
				if (incorrectGuesses >= MaxIncorrectGuesses)
				{
					DisplayAlert("Game Over", $"The word was {puzzle}.", "OK");
				}
			}
		}
	}
}