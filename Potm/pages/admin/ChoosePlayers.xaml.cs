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

		public ChoosePlayers(int cId = 0, int tId = 0, int mId = 0)
		{
			NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();

			teamId = tId;
			clubId = cId;
			if (mId != 0)
			{
				matchId = mId;
			}
		}



		protected override async void OnAppearing()
		{
			flowAllPlayers.FlowItemsSource = await cManager.GetAllPlayers(clubId, teamId);
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
			await manager.choosePlayers(selectedPlayers, teamId, matchId);

			if (teamId != 0){
				eMessage.Text = "Spillere Tilføjet";
                eMessage.TextColor = Color.Green;
			}else{
				eMessage.Text = "Ups noget gik galt";
				eMessage.TextColor = Color.Red;
			}
		}
	}
}
