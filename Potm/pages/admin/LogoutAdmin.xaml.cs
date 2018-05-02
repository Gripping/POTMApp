using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class LogoutAdmin : ContentPage
    {
        public LogoutAdmin()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}
