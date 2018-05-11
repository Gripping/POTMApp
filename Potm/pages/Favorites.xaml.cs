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

            foreach (var fav in favsList) {
                favs.Add(fav);
            }
            favList.FlowItemsSource = favs;
        }

        public async void AddToFavourites(object sender, EventArgs e)
        {
            Button FavBtn = (Button)sender;
            int message = int.Parse(FavBtn.CommandParameter.ToString());

            favTeam t = new favTeam();
            t.clubId = message;

            await App.FavRepo.addFav(t);
        }

        public async void FavDelete(object sender, ItemTappedEventArgs e)
        {
            Favourite tappedItem = (Favourite) e.Item;

            await App.FavRepo.DeleteFav(tappedItem);

            refreshList();

        }

        public async void refreshList()
        {
            var newFavsList = await App.FavRepo.GetFavs();

            FlowObservableCollection<Favourite> newFavs = new FlowObservableCollection<Favourite>();

            foreach (var fav in newFavsList)
            {
                newFavs.Add(fav);
            }
            favList.FlowItemsSource = newFavs;

        }
    }
}
