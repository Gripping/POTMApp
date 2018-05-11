using System;
using System.Collections.Generic;
using CarouselView.FormsPlugin.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using Potm.Data;
using DLToolkit.Forms;
using DLToolkit.Forms.Controls;
using System.Threading.Tasks;

namespace Potm.pages
{
    public partial class Filter : ContentPage
    {
        readonly CollectionManager manager = new CollectionManager();
        public FlowObservableCollection<sport> flowSports = new FlowObservableCollection<sport>();
        int count;
        public int sportId;

        public Filter()
        {
            InitializeComponent();
            NavigationPage.SetHasNavigationBar(this, false);
        }
        void Handle_PositionSelected(object sender, CarouselView.FormsPlugin.Abstractions.PositionSelectedEventArgs e)
        {
            //Debug.WriteLine("Position " + e.NewValue + " selected.");
            count = e.NewValue;

        }

        void Handle_Scrolled(object sender, CarouselView.FormsPlugin.Abstractions.ScrolledEventArgs e)
        {
            //Debug.WriteLine("Scrolled to " + e.NewValue + " percent.");
            //Debug.WriteLine("Direction = " + e.Direction);
        }
        protected override async void OnAppearing()
        {
            var allSports = await manager.GetAllSports();

            foreach (var sport in allSports)
            {
                flowSports.Add(sport);
            }

            carousel.ItemsSource = flowSports;
        }

        public async void onFilterSearch(object sender, EventArgs e)
        {
            

            for (int i = count; i < flowSports.Count; i++)
            {   
                if(i == count){
					sportId = flowSports[i].id;
                }
            }

            await Navigation.PushAsync(new AllTeams(sportId));
        }
    }
}
