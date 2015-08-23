using System;
using System.Collections.Generic;

using Xamarin.Forms;
using MadisonMonkeys;
using MadisonMonkeysViewModel;

namespace MadisonMonkeys
{
	public partial class MonkeyListPage : ContentPage
	{
		MonkeyListViewModel viewModel;
		public MonkeyListPage ()
		{
			InitializeComponent ();

			viewModel = new MonkeyListViewModel();

			ButtonGet.Clicked += async (sender, e) => 
			{
				try {
					ButtonGet.IsEnabled = false;
					await viewModel.GetMonkeysAsync();
					ButtonGet.IsEnabled = true;
				}
				catch(Exception ex) {
					DisplayAlert("Oh no!", "Unable to get monkeys:" +ex.Message, "OK");
				}
			};

			List.ItemTapped += async (sender, e) =>
			{
				var monkey = e.Item;
				var details = new MonkeyPage();
				details.BindingContext = monkey;

				await Navigation.PushAsync(details);

				List.SelectedItem = null;

			};

			BindingContext = viewModel;
		}
	}
}

