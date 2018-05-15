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
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;

namespace Potm
{
    public partial class App : Application
    {
        public static FavRepository FavRepo { get; private set; }
        public static VoteRepo VoteRepo { get; private set; }
        public static int LoggedInClubId;

        public App(string dbPath)
        {

            InitializeComponent();
            FlowListView.Init();

            var navPage = new NavigationPage(new LandingPage());

            navPage.BarBackgroundColor = Color.Transparent;
            navPage.BarTextColor = Color.White;

            MainPage = navPage;

            FavRepo = new FavRepository(dbPath);
            VoteRepo = new VoteRepo(dbPath);
            LoggedInClubId = 0;
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
            if (page != "Potm.pages.Filter")
            {
                var modalPop = Application.Current.MainPage.Navigation.ModalStack;
                if (modalPop.Count() != 0)
                {
                    await ((NavigationPage)Application.Current.MainPage).Navigation.PopModalAsync();
                }
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new Filter());
            }
        }

        public async void favoritesPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.Favorites")
            {
                var modalPop = Application.Current.MainPage.Navigation.ModalStack;
                if (modalPop.Count() != 0)
                {
                    await ((NavigationPage)Application.Current.MainPage).Navigation.PopModalAsync();
                }
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new Favorites());
            }
        }

        public async void logoutPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.Logout")
            {
                var modalPop = Application.Current.MainPage.Navigation.ModalStack;
                if (modalPop.Count() != 0)
                {
                    await ((NavigationPage)Application.Current.MainPage).Navigation.PopModalAsync();
                }
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new LandingPage());
            }
        }

        public async void backButton(object sender, EventArgs e)
        {
            var modalPop = Application.Current.MainPage.Navigation.ModalStack;
            if (modalPop.Count() != 0)
            {
                await ((NavigationPage)Application.Current.MainPage).Navigation.PopModalAsync();
            }
            else
            {
                await ((NavigationPage)Application.Current.MainPage).PopAsync();
            }
        }

        public async void addPlayerPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.admin.AddPlayerPage")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new AddPlayerPage(LoggedInClubId));
            }
        }

        public async void allPlayersPage(object sender, EventArgs e)
        {
            string page = Application.Current.MainPage.Navigation.NavigationStack.Last().ToString();
            if (page != "Potm.pages.admin.OldLandingPage")
            {
                await ((NavigationPage)Application.Current.MainPage).PushAsync(new OldLandingPage(LoggedInClubId));
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
