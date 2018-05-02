using System;

using Xamarin.Forms;

namespace Potm.pages
{
    public class Favorites : ContentPage
    {
        public Favorites()
        {
            Content = new StackLayout
            {
                Children = {
                    new Label { Text = "Hello ContentPage" }
                }
            };
        }
    }
}

