using System;
using System.Collections.Generic;
using Potm.Data;

using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class AddMatch : ContentPage
    {
		public int teamId;
		public int clubId;
		readonly ActionsManager manager = new ActionsManager();

        public AddMatch(int tId, int cId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
			teamId = tId;
			clubId = cId;
        }

		public async void createMatch(object sender, EventArgs e)
		{
			var enemyT = enemyTeam.Text;
			var mLocation = matchLocation.Text;
			var d = date.Date.ToString();

			match newMatch = new match();
			newMatch.enemyTeam = enemyT;
			newMatch.matchLocation = mLocation;
			newMatch.matchTime = d;


			int matchId = await manager.managerCreateMatch(newMatch, teamId);
         

			await Navigation.PushAsync(new ChoosePlayers(clubId, teamId, matchId));
		}
        

    }
}
