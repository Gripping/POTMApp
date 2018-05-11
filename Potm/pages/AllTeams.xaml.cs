//using System;
//using System.Collections.Generic;
//using CarouselView.FormsPlugin.Abstractions;
//using System.Collections.ObjectModel;
//using Xamarin.Forms;
//using System.Diagnostics;
//using Potm.Data;
//using DLToolkit.Forms.Controls;
//using DLToolkit.Forms;
//namespace Potm.pages
//{
//    public partial class AllTeams : ContentPage
//    {
//		int sportId;
//        readonly CollectionManager manager = new CollectionManager();
//		public FlowObservableCollection<club> flowClubs = new FlowObservableCollection<club>();

//        public AllTeams(int sId)
//        {
//            NavigationPage.SetHasNavigationBar(this, false);
//            NavigationPage.SetHasNavigationBar(this, false);
//            InitializeComponent();
//			sportId = sId;
//		}

//		protected override async void OnAppearing()
//		{
//			var filteredClubs = await manager.GetFilteredClubs(sportId);

//			foreach (var c in filteredClubs )
//			{
//				flowClubs.Add(c);
//			}

//			clubList.FlowItemsSource = flowClubs;
				
//		}

//		public async void FlowItemTapped(object sender, ItemTappedEventArgs e)
//        {
//			await Navigation.PushAsync(new ClubPage((club) e.Item));
//        }
//    }
//}

using System;
using System.Collections.Generic;
using CarouselView.FormsPlugin.Abstractions;
using System.Collections.ObjectModel;
using Xamarin.Forms;
using System.Diagnostics;
using Potm.Data;
using DLToolkit.Forms.Controls;
using DLToolkit.Forms;
namespace Potm.pages
{
    public partial class AllTeams : ContentPage
    {
        int sportId;
        readonly CollectionManager manager = new CollectionManager();
		public FlowObservableCollection<club> flowClubs = new FlowObservableCollection<club>();

        public AllTeams(int sId)
        {
            NavigationPage.SetHasNavigationBar(this, false);
            NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
            sportId = sId;
        }



      protected override async void OnAppearing()
      {
          var filteredClubs = await manager.GetFilteredClubs(sportId);

          foreach (var c in filteredClubs )
          {
              flowClubs.Add(c);
          }

			clubList.FlowItemsSource = flowClubs;



      }

        public async void FlowItemTapped(object sender, ItemTappedEventArgs e)
        {
          await Navigation.PushAsync(new ClubPage((club) e.Item));
        }   
    }
}
