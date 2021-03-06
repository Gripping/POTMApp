﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Potm.Data;
using Xamarin.Forms;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;

namespace Potm.pages.admin
{
    public partial class OldLandingPage : ContentPage
    {

        public FlowObservableCollection<teams> flowTeams = new FlowObservableCollection<teams>();
        readonly CollectionManager manager = new CollectionManager();
		public int clubId;


        public OldLandingPage(int clubId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            //NavigationPage.SetHasBackButton(this, false);
            this.clubId = clubId;
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
                    if (flowTeams.All(t => t.name != team.name))
                    {
                        flowTeams.Add(team);
                    }
                }
                flowListTest.FlowItemsSource = flowTeams;

            }
        }

		public async void Handle_FlowItemTapped(object sender, ItemTappedEventArgs e){
			teams team = (teams)e.Item;
			await Navigation.PushAsync(new SingleTeam(team, clubId));
		}

    		public async void navAddTeam(object sender, EventArgs e){
    			await Navigation.PushAsync(new AdminAddTeam(clubId));

    		}

    }
}
