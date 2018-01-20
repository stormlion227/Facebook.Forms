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
using Java.Lang;

namespace Com.Facebook
{
    public partial class GraphRequestAsyncTask : AsyncTask
    {
        protected override Java.Lang.Object DoInBackground(params Java.Lang.Object[] @params)
        {
            return (Java.Lang.Object)DoInBackground_Invoke((Java.Lang.Void[])@params);
        }
    }
}