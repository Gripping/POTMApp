using System;
using System.Collections.Generic;
using Potm.Data;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;

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
        
        protected override async void OnAppearing()
		{
            
			BindingContext = match;

			flowListPlayers.FlowItemsSource = match.matchPlayers;

		}
        
    }
}
