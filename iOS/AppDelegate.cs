using System;
using System.Collections.Generic;
using System.Linq;
using Foundation;
using UIKit;
using DLToolkit.Forms.Controls;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

namespace Potm.iOS
{
    [Register("AppDelegate")]
	[assembly: ExportRenderer(typeof(FlowListViewInternalCell), typeof(FlowListViewInternalCellRenderer))]
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
