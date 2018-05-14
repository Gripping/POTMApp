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
        int sportId;

        public AdminAddTeam(int clubId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();

        }
       
		private async void btnCreateTeam(object sender, EventArgs e)
        {
			newTeam team = new newTeam()
			{
				teamName = teamName.Text
				managerName = coachName.Text,
				managerPass = coachPassword.Text,


            };

            var picker = dropDownSport;
            sport typeOfSport = (sport)picker.SelectedItem;
            sportId = typeOfSport.id;

            bool status = await manager.managerCreatePlayer(player, clubId, sportId);

            if (status == true)
            {
                pName.Text = "";
                pNumber.Text = "";
                pAge.Text = "";
                pPosition.Text = "";

                eMessage.Text = "Spiller tilføjet!";
                eMessage.TextColor = Color.Green;
            }
            else
            {
                eMessage.Text = "Ups! Noget gik galt, prøv igen";

            }
        }
       
    }
   
}
