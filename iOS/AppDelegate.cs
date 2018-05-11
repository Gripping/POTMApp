﻿using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;

namespace Potm.iOS
{
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            CarouselView.FormsPlugin.iOS.CarouselViewRenderer.Init();
            string dbPath = FileAccessHelper.GetLocalFilePath("favs.db3");
            LoadApplication(new App(dbPath));
            return base.FinishedLaunching(app, options);
        }
    }
}
