using System;
using System.Collections.Generic;
using Potm.Data;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;
using System.Linq;
               

using Xamarin.Forms;
using UIKit;

namespace Potm.pages.admin
{
	public partial class ChoosePlayers : ContentPage
	{
		public ActionsManager manager = new ActionsManager();
		public CollectionManager cManager = new CollectionManager();
		public FlowObservableCollection<player> flowPlayers = new FlowObservableCollection<player>();
		public List<player> selectedPlayers = new List<player>();
		public match match = new match();
		public int clubId;
		public int matchId;
		public int teamId;

		public ChoosePlayers(int cId = 0, int teamId = 0, int mId = 0)
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();


			clubId = cId;
			if (mId != 0)
			{
				matchId = mId;
			}
		}



		protected override async void OnAppearing()
		{
			//flowAllPlayers.FlowItemsSource = flowPlayers;
			flowAllPlayers.FlowItemsSource = await cManager.GetAllPlayers(clubId, matchId);

		}

		protected async void addPlayerToList(object sender, ItemTappedEventArgs e)
		{
			player p = (player)e.Item;
			if(selectedPlayers.All(x => x.id != p.id)) {
				selectedPlayers.Add(p);            
			}else{
				selectedPlayers.Remove(p);
			}
		}

		protected async void sendPlayers(object sender, EventArgs e)
		{
			await manager.choosePlayers(selectedPlayers, 0, matchId);
		}
	}
}
