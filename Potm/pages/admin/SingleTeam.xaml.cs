using System;
using System.Collections.Generic;
using Potm.Data;

using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class SingleTeam : ContentPage
    {
		readonly team team = new team();
		readonly CollectionManager manager = new CollectionManager();
        readonly int teamId;

		public SingleTeam(teams team)
        {
            InitializeComponent();

			teamId = team.id;
		}

		protected override async void OnAppearing()
		{
			var cTeam = await manager.GetTeam(teamId);
			BindingContext = cTeam;
		}

    }
}
