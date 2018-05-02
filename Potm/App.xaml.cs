using Potm.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Potm.pages.admin;
using Potm.pages;

namespace Potm
{
    public partial class App : Application
    {
        public App()
        {
            
            InitializeComponent();

            var navPage = new NavigationPage(new AllTeams());

            navPage.BarBackgroundColor = Color.FromHex("#8B2727");
            navPage.BarTextColor = Color.White;

            MainPage = navPage;

           



        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        public async void filterPage(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new Filter());
        }

        public async void favoritesPage(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new Favorites());
        }

        public async void logoutPage(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new Logout());
        }

        public async void backButton(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PopAsync();
        }

        public async void addPlayerPage(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new AddPlayer());
        }

        public async void allPlayersPage(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new AllTeams());
        }

        public async void logoutAdminPage(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PushAsync(new LogoutAdmin());
        }
    }
} 