using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Potm.Data;
using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class NewLandingPage : ContentPage
    {
        public NewLandingPage()
        {
            //NavigationPage.SetHasBackButton(this, false);
            NavigationPage.SetBackButtonTitle(this, "Menu");
            NavigationPage.SetHasNavigationBar(this, false);

            InitializeComponent();
        }
    }
}