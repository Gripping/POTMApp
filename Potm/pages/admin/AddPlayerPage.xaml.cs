using System;
using System.Collections.Generic;
using Potm.Data;
using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class AddPlayerPage : ContentPage
    {
        readonly ActionsManager manager = new ActionsManager();
		readonly CollectionManager cManager = new CollectionManager();
		public List<sport> AllSports = new List<sport>();
		public int clubId;
		int sportId;

        public AddPlayerPage(int cId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
			clubId = cId;
            
        }

        protected override async void OnAppearing()
        {
            AllSports = await cManager.GetAllSports();
			dropDownSport.ItemsSource = AllSports;
		}

        private async void btnCreatePlayer(object sender, EventArgs e)
        {
			player player = new player()
			{
				playerName = pName.Text,
				playerNumber = int.Parse(pNumber.Text),
				playerAge = pAge.Text,    
				playerPosition = pPosition.Text
				                  
            };

			var picker = dropDownSport;
			sport typeOfSport = (sport)picker.SelectedItem;
			sportId = typeOfSport.id;
            
			bool status = await manager.managerCreatePlayer(player, clubId, sportId);

			if(status == true){
				pName.Text = "";
				pNumber.Text = "";
				pAge.Text = "";
				pPosition.Text = "";

				eMessage.Text = "Spiller tilføjet!";
				eMessage.TextColor = Color.Green;
			}else{
				eMessage.Text = "Ups! Noget gik galt, prøv igen";

			}
        }


    }
}
