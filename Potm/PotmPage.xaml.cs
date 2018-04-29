using Potm.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Potm
{
    public partial class PotmPage : ContentPage
    {
        readonly IList<teams> teams = new ObservableCollection<teams>();
        readonly CollectionManager manager = new CollectionManager();

        public PotmPage()
        {
			BindingContext = teams;
            InitializeComponent();
        }

        async void OnRefresh(object sender, EventArgs e)
        {
            var teamsCollection = await manager.GetTeams();

            foreach(teams team in teamsCollection)
            {
                if(teams.All(t => t.name != team.name)){
                    teams.Add(team);
                }   
            }
        }
    }
}
