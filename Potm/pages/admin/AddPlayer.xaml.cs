using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net.Http;
using Potm.Data;
using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class AddPlayer : ContentPage
    {
        readonly ActionsManager manager = new ActionsManager();

        public AddPlayer()
        {
            NavigationPage.SetBackButtonTitle(this, "Menu");

            InitializeComponent();
        }

        private async void btnCreatePlayer(object sender, EventArgs e)
        {
            var name = playerName.Text;

            await manager.managerCreatePlayer(name);
        }
    }
}
