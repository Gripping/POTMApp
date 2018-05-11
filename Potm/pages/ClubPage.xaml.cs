using System;
using System.Collections.Generic;
using Potm.Data;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;


using Xamarin.Forms;

namespace Potm.pages
{
    public partial class ClubPage : ContentPage
    {
		readonly club club = new club();
        readonly CollectionManager manager = new CollectionManager();
        readonly int clubId;
		readonly int sportId;
        public FlowObservableCollection<teams> flowClubTeams = new FlowObservableCollection<teams>();

		public ClubPage(club c, int sId)
        {
			NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
			clubId = c.id;
			sportId = sId;

        }

		protected override async void OnAppearing()
		{
			var cClub = await manager.GetClub(clubId, sportId);

			foreach (var t in cClub.clubTeams)
			{
			flowClubTeams.Add(t);
			}
			BindingContext = cClub;
			flowAllTeams.FlowItemsSource = flowClubTeams;
		}

		public async void FlowSingleClubTapped(object sender, ItemTappedEventArgs e)
        {
			await Navigation.PushAsync(new TeamPage((teams)e.Item));
        }
    }
}
