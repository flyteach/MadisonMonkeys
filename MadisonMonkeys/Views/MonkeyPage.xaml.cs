using System;
using System.Collections.Generic;

using Xamarin.Forms;

using Refractored.Xam.TTS;
using Refractored.Xam.TTS.Abstractions;

namespace MadisonMonkeys
{
	public partial class MonkeyPage : ContentPage
	{
		public MonkeyPage ()
		{
			InitializeComponent ();

			OnPressed.Clicked += async (sender, e) => 
			{
				
				CrossTextToSpeech.Current.Speak(TextDetails.Text, false, null, 0.8f, 0.1f, null);
			};



		}
	}
}

