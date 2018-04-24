using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Potm.Data;
using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class OldLandingPage : ContentPage
    {
        readonly IList<teams> teams = new ObservableCollection<teams>();
        readonly CollectionManager manager = new CollectionManager();
        readonly int clubId;


        public OldLandingPage(int clubId)
        {
			NavigationPage.SetBackButtonTitle(this, "Menu");
            //NavigationPage.SetHasBackButton(this, false);
            this.clubId = clubId;

            BindingContext = teams;
            InitializeComponent();
			this.OnViewShown();
        }

        public async void OnViewShown()
        {
            var teamsCollection = await manager.GetTeams(clubId);

            if (teamsCollection.Count != 0)
            {
                foreach (teams team in teamsCollection)
                {
                    if (teams.All(t => t.name != team.name))
                    {
                        teams.Add(team);
                    }
                }
            }
            else
            {
                await Navigation.PushAsync(new NewLandingPage());
            }
        }
    }
}