using System;
using System.Collections.Generic;
using DLToolkit.Forms;
using DLToolkit.Forms.Controls;
using Potm.Data;

using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class AdminSeePlayers : ContentPage
    {
		public CollectionManager cManager = new CollectionManager();
		public int teamId;
		public int clubId;

		public AdminSeePlayers(int tId, int cId)
        {
			NavigationPage.SetHasNavigationBar(this, false);
			
            InitializeComponent();
			teamId = tId;
			clubId = cId;
           
            
        }

		protected override async void OnAppearing()
        {
			flowAllPlayers.FlowItemsSource = await cManager.GetAllPlayers(clubId, teamId);

			var text = await cManager.GetTeam(teamId);

			headerText.Text = "SPILLERE PÅ HOLD: " + text.name;
        }
    }
}
