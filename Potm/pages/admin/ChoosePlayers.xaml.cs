using System;
using System.Collections.Generic;
using Potm.Data;

using Xamarin.Forms;

namespace Potm.pages.admin
{
    public partial class ChoosePlayers : ContentPage
    {
		readonly ActionsManager manager = new ActionsManager();
		public player player = new player();
		public int clubId;

        
        

        public ChoosePlayers(int cId)
        {
            InitializeComponent();

			clubId = cId;
        }
    }
}
