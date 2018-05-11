using System;
using System.Collections.Generic;
using Potm.Data;
using DLToolkit.Forms;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Potm.pages;

namespace Potm.pages
{
    public partial class TeamPage : ContentPage
    {

		int teamId;
		readonly CollectionManager manager = new CollectionManager();
		public FlowObservableCollection<match> flowSingleTeam = new FlowObservableCollection<match>();

		public TeamPage(teams tId)
        {
			NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
			teamId = tId.id;
        }


		protected override async void OnAppearing()
		{
			var singleTeam = await manager.GetTeam(teamId);

			foreach (var t in singleTeam.matches)
			{
				flowSingleTeam.Add(t);
			}

			BindingContext = singleTeam;

			flowTeamMatches.FlowItemsSource = flowSingleTeam;
        

		}


		public async void matchTapped(object sender, Xamarin.Forms.ItemTappedEventArgs e)
		{
			await Navigation.PushAsync(new PlayersFromMatch((match) e.Item));
		}
    }
}
