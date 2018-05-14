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
		
        readonly CollectionManager manager = new CollectionManager();
        public match match;
		public motmWinner winner = new motmWinner();

        public ManOfTheMatch(match cMatch)
        {
			NavigationPage.SetHasNavigationBar(this, false);
            InitializeComponent();
         
			match = cMatch;

        }

        protected override async void OnAppearing()
        {
            winner = await manager.GetMotm(match.id);
			BindingContext = winner;
		}
    }
}
