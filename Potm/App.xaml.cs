using Xamarin.Forms;
<<<<<<< HEAD
=======
using Potm.pages;
using Potm.pages.admin;
>>>>>>> fb19101bb97b94619cbdde78baeec22515e1c43a

namespace Potm
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

<<<<<<< HEAD
            var navPage = new NavigationPage(new LandingPage());
=======
            var navPage = new NavigationPage(new AdminAddTeam());
>>>>>>> fb19101bb97b94619cbdde78baeec22515e1c43a

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
