using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Potm.Data;
using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class NewLandingPage : ContentPage
    {
		public int clubId;

        public NewLandingPage(int cId)
        {
            //NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetBackButtonTitle(this, "Menu");
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
			clubId = cId;
        }

		public async void CreateTeam(object sender, EventArgs e)
		{
			await Navigation.PushAsync(new AdminAddTeam(clubId));
		}

    }
}