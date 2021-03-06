﻿using System;
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

namespace Stormlion.Facebook.Droid
{
    public class Platform
    {
        public static Context Context { get; set; }

        public static void Init(Context context)
        {
            Context = context;

            DependencyService.Register<FBLoginManagerImplement>();
            DependencyService.Register<FBGraphRequestImplement>();

            CallBackManager = Com.Facebook.CallbackManagerFactory.Create();
        }

        public static Com.Facebook.ICallbackManager CallBackManager;

        public static void OnActivityResult(int requestCode, Result resultCode, Intent data)
        {
            CallBackManager.OnActivityResult(requestCode, (int)resultCode, data);
        }
    }
}