using System;
using System.Collections.Generic;
using Potm.Data;
using DLToolkit.Forms;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Potm.pages;
using System.Linq;

namespace Potm.pages.admin
{
    public partial class SingleTeam : ContentPage
    {
		public FlowObservableCollection<match> AllMatches = new FlowObservableCollection<match>();
        public teams cTeam = new teams();
        public team t = new team();
		readonly CollectionManager manager = new CollectionManager();
        readonly int teamId;
		public int clubId;

		public SingleTeam(teams cT, int cId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

            teamId = cT.id;
            cTeam = cT;
			      clubId = cId;

            cName.Text = cT.clubName;
            cName2.Text = cT.clubName;
            tSport.Text = cT.sport.sportName;
            tM.Text = cT.coach.name;
        }

        protected override async void OnAppearing()
        {
            t = await manager.GetTeam(teamId);

            foreach (var singleMatch in t.matches)
            {
                if(AllMatches.All(x => x.id != singleMatch.id))
                {
                    singleMatch.clubName = cTeam.clubName;
                    AllMatches.Add(singleMatch);
                }
            }

            flowListAllMatches.FlowItemsSource = AllMatches;

		}

		public async void createMatchBtn(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AddMatch(teamId, clubId));
		}
		public async void seSpillere(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AdminSeePlayers(teamId, clubId));
		}

    }
}
