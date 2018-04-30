using System;
using System.Collections.Generic;
using CarouselView.FormsPlugin.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;

namespace Potm.pages
{
    public partial class Filter : ContentPage
    {
        public Filter()
        {
            InitializeComponent();

            var myCarousel = new CarouselViewControl();
            myCarousel.ItemsSource = new ObservableCollection<int> { 1, 2, 3, 4, 5 };
            myCarousel.Position = 0; //default
            myCarousel.InterPageSpacing = 10;
            myCarousel.Orientation = CarouselViewOrientation.Horizontal;
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

    }
}
