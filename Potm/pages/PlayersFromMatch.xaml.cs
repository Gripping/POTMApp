using System;
using System.Collections.Generic;
using Potm.Data;
using DLToolkit.Forms;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;

namespace Potm.pages
{
	 
    public partial class PlayersFromMatch : ContentPage
    {
		readonly CollectionManager manager = new CollectionManager();
		public FlowObservableCollection<player> FlowMatchDetails = new FlowObservableCollection<player>();
		public match match = new match();

		public PlayersFromMatch(match m)
        {
            NavigationPage.SetHasNavigationBar(this, false);
			InitializeComponent();

			match = m;
        }
        
        protected override void OnAppearing()
		{   
			BindingContext = match;

			flowListPlayers.FlowItemsSource = match.matchPlayers;
		}

        public async void GetSinglePlayer(object sender, ItemTappedEventArgs e)
        {
            var PlayerDetail = new PlayerDetail((player) e.Item, match.clubImage.ToString(), match.clubName, match.id);
            await Navigation.PushModalAsync(PlayerDetail);
        }
    }
}
