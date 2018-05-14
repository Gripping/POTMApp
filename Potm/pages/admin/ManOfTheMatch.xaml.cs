using System;
using System.Collections.Generic;
using DLToolkit.Forms;
using DLToolkit.Forms.Controls;
using Potm.Data;

using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class ManOfTheMatch : ContentPage
    {
		public FlowObservableCollection<teams> flowTeams = new FlowObservableCollection<teams>();
        readonly CollectionManager manager = new CollectionManager();
        public int clubId;

        public ManOfTheMatch()
        {
            InitializeComponent();

			//nameOfWinner.Text = playerName;
			//numberOfVotes.Text = "Med: " + __votes__ + " Stemmer";


        }

		public async void OnAppearing()
		{
			var teamsCollection = await manager.GetTeams(clubId);

			flowListTest.FlowItemsSource = flowTeams;

		}
    }
}
