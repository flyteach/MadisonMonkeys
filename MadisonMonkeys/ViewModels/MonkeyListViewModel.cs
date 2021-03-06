﻿using System;
using MadisonMonkeys;

using System.ComponentModel;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using System.Net.Http;
using Newtonsoft.Json;

namespace MadisonMonkeysViewModel
{
	public class MonkeyListViewModel:INotifyPropertyChanged 
	{

		public ObservableCollection<Monkey> MonkeyList { get; set;}


		public MonkeyListViewModel ()
		{
			MonkeyList = new ObservableCollection<Monkey> ();
		}

		private bool busy = false;

		public bool IsBusy {
			get { return busy; }
			set {
				if (busy == value)
					return;
				busy = value;
				OnPropertyChanged ("IsBusy");
			}
		}

		public async Task GetMonkeysAsync()
		{
			//IsBusy = true;
			//Get Monkeys and stuff
			//IsBusy = false;

			if (IsBusy)
				return;

			try {
				IsBusy = true;

				var client = new HttpClient();

				var json = await client.GetStringAsync("http://montemagno.com/monkeys.json");

				var list = JsonConvert.DeserializeObject<List<Monkey>>(json);

				foreach(var item in list) {
					MonkeyList.Add(item);
				}

			}
			finally {
				IsBusy = false;
			}
		}

		#region INotifyPropertyChanged implementation

		public event PropertyChangedEventHandler PropertyChanged;

		// Watch out! Had above typed as ProgressChangedEventHandler

		public void OnPropertyChanged(string name)
		{
			var changed = PropertyChanged;
			if (changed == null)
				return;

			changed (this, new PropertyChangedEventArgs (name));
		}

		#endregion 
	}
}

