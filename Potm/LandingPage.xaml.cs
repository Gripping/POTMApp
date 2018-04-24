using Potm.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Potm.pages.admin;

namespace Potm
{
    public partial class LandingPage : ContentPage
    {
        
        public LandingPage()
        {
            InitializeComponent();

            var EmptyClubId = 1102;
            var FullClubId = 1075;

            GetFullCollection.Clicked += (s, e) => Navigation.PushAsync(new OldLandingPage(FullClubId));
            GetEmptyCollection.Clicked += (s, e) => Navigation.PushAsync(new OldLandingPage(EmptyClubId));
            AddPlayer.Clicked += (s, e) => Navigation.PushAsync(new AddPlayer());
        }
    }
}
