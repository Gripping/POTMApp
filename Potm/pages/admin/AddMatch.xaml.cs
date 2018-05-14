using System;
using System.Collections.Generic;
using Potm.Data;

using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class AddMatch : ContentPage
    {
		public int teamId;
		readonly ActionsManager manager = new ActionsManager();
        public AddMatch(int tId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
			teamId = tId;
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
         

			await Navigation.PushAsync(new ChoosePlayers(0, teamId, matchId));
		}
        

    }
}
