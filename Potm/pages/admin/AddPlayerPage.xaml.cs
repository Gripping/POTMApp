using System;
using System.Collections.Generic;
using Potm.Data;
using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class AddPlayerPage : ContentPage
    {
        readonly ActionsManager manager = new ActionsManager();

        public AddPlayerPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        private async void btnCreatePlayer(object sender, EventArgs e)
        {
            player player = new player()
            {
                playerName = pName.ToString()
            };

            await manager.managerCreatePlayer(player);
        }
    }
}
