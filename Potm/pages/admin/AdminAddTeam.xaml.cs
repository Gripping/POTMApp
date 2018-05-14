using Potm.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Potm.pages;

namespace Potm.pages.admin
{
    public partial class AdminAddTeam : ContentPage
    {
		readonly ActionsManager manager = new ActionsManager();
        readonly CollectionManager cManager = new CollectionManager();
        public List<sport> AllSports = new List<sport>();
        public int clubId;

        public AdminAddTeam(int cId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
			clubId = cId;
        }

		protected override async void OnAppearing()
        {
            AllSports = await cManager.GetAllSports();
			listOfSports.ItemsSource = AllSports;
        }
       
		private async void btnCreateTeam(object sender, EventArgs e)
        {
			var picker = listOfSports;
            sport typeOfSport = (sport)picker.SelectedItem;
            int sId = typeOfSport.id;
			newTeam team = new newTeam()
			{
				teamName = teamName.Text,
				managerName = coachName.Text,
				managerPass = coachPassword.Text,
				managerEmail = managerEmail.Text,
				sportId = sId               

            };
            
			if (coachPassword.Text == coachPassword2.Text && coachPassword.Text.Length > 9)
            {
				bool status = await manager.managerCreateTeam(team, clubId);

				if (status == true)
                {
					string username = coachName.Text.Replace(" ", "").ToLower();
                    teamName.Text = "";
                    coachName.Text = "";
                    coachPassword.Text = "";
                    coachPassword2.Text = "";
                    managerEmail.Text = "";

                    eMessage.Text = "Hold Tilføjet" +
                                    "";
                    eMessage.TextColor = Color.Green;
                    eMessage2.Text = "Hold leder login: " + username + " SKRIV DETTE NED ";
                    eMessage2.TextColor = Color.Green;
                }
                else
                {
                    eMessage.Text = "Ups! Noget gik galt, prøv igen";

                }
            }
            else
            {
				wrongPassword.Text = "Passwords skal være ens eller indeholde over 10 tegn";
            }


           
        }

		private async void addPlayersToTeam(object sender, EventArgs e)
        {
			await Navigation.PushAsync(new ChoosePlayers(clubId));
        }
       
    }
   
}
