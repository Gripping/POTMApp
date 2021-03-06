﻿using System;
using System.Collections.Generic;
using Potm.Data;
using DLToolkit.Forms;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Potm.pages;
using System.Linq;

namespace Potm.pages
{
    public partial class TeamPage : ContentPage
    {

		int teamId;
		readonly CollectionManager manager = new CollectionManager();
		public FlowObservableCollection<match> flowSingleTeam = new FlowObservableCollection<match>();
		public string clubName;
		public object clubImage;

		public TeamPage(teams tId, string cName, object cImage)
        {
			NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
			teamId = tId.id;
			clubName = cName;
			clubImage = cImage;
        }


		protected override async void OnAppearing()
		{
			var singleTeam = await manager.GetTeam(teamId);

			foreach (var t in singleTeam.matches)
			{
				t.clubName = clubName;
				t.clubImage = clubImage;
                if (flowSingleTeam.All(x => x.id != t.id))
                {
					flowSingleTeam.Add(t);
                }
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
