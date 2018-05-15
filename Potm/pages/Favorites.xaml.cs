using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Potm.Data;
using Xamarin.Forms;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;

namespace Potm.pages
{
    public partial class Favorites : ContentPage
    {
        public FlowObservableCollection<Favourite> favs = new FlowObservableCollection<Favourite>();

        public Favorites()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            var favsList = await App.FavRepo.GetFavs();

			var test = favsList.Count;

            foreach (var fav in favsList) {
				favs.Add(fav);
            }
            favList.FlowItemsSource = favs;

        }

        public async void FavDelete(object sender, EventArgs e)
        {
            Button deleteBtn = (Button)sender;
            var Message = int.Parse(deleteBtn.CommandParameter.ToString());

            Favourite favorit = new Favourite();

            var favsList = await App.FavRepo.GetFavs();

            foreach (var fav in favsList)
            {
                if(fav.clubId == Message){
                    favorit = fav;
                }
            }

            await App.FavRepo.DeleteFav(favorit);

            refreshList();

        }

        public async void refreshList()
        {
            var newFavsList = await App.FavRepo.GetFavs();

            FlowObservableCollection<Favourite> newFavs = new FlowObservableCollection<Favourite>();

            foreach (var fav in newFavsList)
            {
                if (newFavs.All(x => x.clubId != fav.clubId))
                {
                    newFavs.Add(fav);
                }
            }
            favList.FlowItemsSource = newFavs;

        }

        public async void GoToTeam(object sender, ItemTappedEventArgs e)
        {
			var fav = (Favourite)e.Item;
            teams team = new teams();
            team.id = fav.clubId;
            team.clubName = fav.clubName;
            team.name = fav.teamName;
            team.gender = fav.teamGender;

            await Navigation.PushAsync(new TeamPage(team, fav.clubName, fav.clubLogo));
        }
    }
}
