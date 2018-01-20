using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;

namespace Stormlion.Facebook.Common.Droid
{
    public class Platform
    {
        public static void Init()
        {
            DependencyService.Register<FBLoginManagerImplement>();
        }
    }
}