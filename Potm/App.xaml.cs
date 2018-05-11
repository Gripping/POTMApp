﻿using Potm.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Potm.pages.admin;
using Potm.pages;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;

namespace Potm
{
    public partial class App : Application
    {
        readonly int clubId;

        public App()
        {

            InitializeComponent();
            FlowListView.Init(); 

			var navPage = new NavigationPage(new ClubPage(1075));

            navPage.BarBackgroundColor = Color.Transparent;
            navPage.BarTextColor = Color.White;

            MainPage = navPage;


            clubId = 1128;
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
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.Filter") {
				await ((NavigationPage)Application.Current.MainPage).PushAsync(new Filter());
            }
        }

        public async void favoritesPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.Favorites")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new Favorites());
            }
        }

        public async void logoutPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.Logout")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new Logout());
            }
        }

        public async void backButton(object sender, EventArgs e)
        {
            await ((NavigationPage)Application.Current.MainPage).PopAsync();
        }

        public async void addPlayerPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.admin.AddPlayerPage")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new AddPlayerPage());
            }
        }

        public async void allPlayersPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.admin.OldLandingPage")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new OldLandingPage(clubId));
            }
        }

        public async void logoutAdminPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.admin.LogoutAdmin")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new LogoutAdmin());
            }
        }
    }
}
