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

namespace Stormlion.Facebook.Common.Droid
{
    public class FBAccessTokenImplement : IFBAccessToken
    {
        public ICollection<string> GetDeclinedPermissions()
        {
            return Com.Facebook.AccessToken.CurrentAccessToken.Permissions;
        }

        public ICollection<string> GetPermissions()
        {
            return Com.Facebook.AccessToken.CurrentAccessToken.DeclinedPermissions;
        }
    }
}