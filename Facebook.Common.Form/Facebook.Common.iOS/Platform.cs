using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Xamarin.Forms;

namespace Facebook.Common.iOS
{
    public class Platform
    {
        public static void Init()
        {
            DependencyService.Register<FBLoginManagerImplement>();
            DependencyService.Register<FBGraphRequestImplement>();
        }
    }
}