using System;
using System.Collections.Generic;
using Potm.Data;
using Xamarin.Forms;

namespace Potm.pages
{
    public partial class PlayerDetail : ContentPage
    {
        public player player = new player();
        public int matchId;
        readonly ActionsManager manager = new ActionsManager();

        public PlayerDetail(player p, string clubImage, string clubName, int mId)
        {
            InitializeComponent();
            player = p;
            BindingContext = player;

            matchId = mId;
            cName.Text = clubName;
            cImage.Source = clubImage;
            pNumber.Text = "#" + player.playerNumber;
            playerNumberInline.Text = "ER DU SIKKER PÅ DU VIL STEMME PÅ #" + player.playerNumber + " SOM PLAYER OF THE MATCH";
        }

        public async void tryVote(object sender, EventArgs e)
        {
            
            vote newVote = new vote();

            newVote.playerId = player.id;
            newVote.matchId = matchId;
            var deviceId = await App.VoteRepo.GetDeviceId();

            newVote.deviceId = deviceId.id;

            bool status = await manager.votingHandler(newVote);

            if (status == false)
            {
                eMessage.IsVisible = true;
                eMessage.Text = "Du har allerede stemt!";
            }
            else
            {
                succes.IsVisible = true;
                succes.BackgroundColor = Color.FromHsla(255, 255, 255, 0.8);
                newPNumber.Text = "#" + player.playerNumber;
                transparentBox.IsVisible = false;
                transparentBoxText.IsVisible = false;
            }

        }
    }
}
