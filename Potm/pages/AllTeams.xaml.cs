using System;
using System.Collections.Generic;
using CarouselView.FormsPlugin.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;

namespace Potm.pages
{
    public partial class AllTeams : ContentPage
    {
        public AllTeams()
        {
            NavigationPage.HasNavigationBarProperty(this, false);
            InitializeComponent();
        }
    }
}
