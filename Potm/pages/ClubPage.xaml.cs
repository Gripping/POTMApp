using System;
using System.Collections.Generic;
using Potm.Data;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;


using Xamarin.Forms;
using System.Linq;

namespace Potm.pages
{
    public partial class ClubPage : ContentPage
    {
        public singleClub cClub = new singleClub();
        readonly CollectionManager manager = new CollectionManager();
        readonly int clubId;
		readonly int sportId;
        public string teamName;
		public string teamGender;
        public string sportName;
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
            
            cClub = await manager.GetClub(clubId, sportId);

			foreach (var t in cClub.clubTeams)
			{
                if (flowClubTeams.All(x => x.id != t.id))
                {
					flowClubTeams.Add(t);
                }
			}
			BindingContext = cClub;
			flowAllTeams.FlowItemsSource = flowClubTeams;
		}

		public async void FlowSingleClubTapped(object sender, ItemTappedEventArgs e)
        {
			await Navigation.PushAsync(new TeamPage((teams)e.Item, cClub.clubName, cClub.clubImage));
        }

        public async void AddToFavourites(object sender, EventArgs e)
        {
            Button FavBtn = (Button)sender;
            int message = int.Parse(FavBtn.CommandParameter.ToString());

            favTeam t = new favTeam();
            t.clubId = message;
            t.clubName = cClub.clubName;
			t.clubLogo = cClub.clubImage.ToString();

            foreach (var team in cClub.clubTeams) {
                if (message == team.id) {
					teamName = team.name;
					teamGender = team.gender;
					sportName = team.sport.sportName;
                }
            }
            t.teamName = teamName;
            t.teamGender = teamGender;
			t.sportName = sportName;

			await App.FavRepo.addFav(t);
        }
    }
}
