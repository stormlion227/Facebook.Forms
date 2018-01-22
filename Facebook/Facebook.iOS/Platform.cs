using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;
using Stormlion.Facebook.iOS.Binding;

namespace Stormlion.Facebook.iOS
{
    public class Platform
    {
        public static bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            DependencyService.Register<FBLoginManagerImplement>();
            DependencyService.Register<FBGraphRequestImplement>();

            return FBSDKApplicationDelegate.Instance.DidFinishLaunching(app, options);
        }

        public static bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
        {
            return FBSDKApplicationDelegate.Instance.OpenURL(app, url, options);
        }
    }
}