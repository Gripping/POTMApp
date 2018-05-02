using System;
using System.Collections.Generic;

using Xamarin.Forms;

namespace Potm.pages
{
    public partial class FrontPage : ContentPage
    {
        public FrontPage()
        {
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
        }
    }
}
