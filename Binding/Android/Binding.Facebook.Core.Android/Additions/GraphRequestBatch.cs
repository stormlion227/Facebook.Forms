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
    public partial class GraphRequestBatch : global::Java.Util.AbstractList
    {
        public override Java.Lang.Object Get(int index)
        {
            return (Java.Lang.Object)Get_Invoke(index);
        }
    }
}