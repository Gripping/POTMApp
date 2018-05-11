using System;
using System.Collections.Generic;
using CarouselView.FormsPlugin.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using Potm.Data;

namespace Potm.pages
{
    public partial class AllTeams : ContentPage
    {
		int sportId;
        readonly CollectionManager manager = new CollectionManager();

        public AllTeams(int sId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
			sportId = sId;
		}

		protected override async void OnAppearing()
		{
			var filteredClubs = await manager.GetFilteredClubs(sportId);
		}
    }
}
