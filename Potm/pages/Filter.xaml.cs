using System;
using System.Collections.Generic;
using CarouselView.FormsPlugin.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using Potm.Data;

namespace Potm.pages
{
    public partial class Filter : ContentPage
    {
		readonly CollectionManager manager = new CollectionManager();
        
        public Filter()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);

            
        }
        void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            Debug.WriteLine("Position " + e.NewValue + " selected.");
        }

        void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            Debug.WriteLine("Direction = " + e.Direction);
        }
		protected override async void OnAppearing()
        {
			BindingContext = await manager.GetAllSports();
        }
        

    }
}
