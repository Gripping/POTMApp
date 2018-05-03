using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Potm.Data;
using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class LoginPage : ContentPage
    {
        readonly IList<teams> teams = new ObservableCollection<teams>();
        readonly ActionsManager actionsManager = new ActionsManager();
        readonly CollectionManager collectionManager = new CollectionManager();

        public LoginPage()
        {
            //NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }

        public async void loginManager(object sender, EventArgs e){
            string u = username.Text;
            string p = password.Text;
            eMessage.Text = "";
            manager manager;

            if( u != "" && p != null){
				manager = await actionsManager.managerLogin(u, p);
				
				if(manager.clubId != 0)
				{
                    var teamsCollection = await collectionManager.GetTeams(manager.clubId);

                    if (teamsCollection.Count != 0)
                    {
                        await Navigation.PushAsync(new OldLandingPage(manager.clubId));
                    }
                    else
                    {
                        await Navigation.PushAsync(new NewLandingPage());
                    }
                }
                else{
                    eMessage.Text = "Brugernavn eller adgangskode er forkert";
                }
            }
            else{
                eMessage.Text = "Udfyld venligst brugernavn og adgangskode";
            }
        }
    }
}
