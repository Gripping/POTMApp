using Xamarin.Forms;
using Potm.pages;
using Potm.pages.admin;

namespace Potm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            var navPage = new NavigationPage(new AddMatch());

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
    }
}
