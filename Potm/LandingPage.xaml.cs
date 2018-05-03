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
    public partial class LandingPage : ContentPage
    {

        public LandingPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();

            managerLogin.Clicked += (s, e) => Navigation.PushAsync(new LoginPage());
        }
    }
}
