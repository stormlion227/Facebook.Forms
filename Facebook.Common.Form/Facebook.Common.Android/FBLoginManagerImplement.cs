using Plugin.CurrentActivity;
using System;
using System.Collections.Generic;

namespace Stormlion.Facebook.Common.Droid
{
    public class FBLoginManagerImplement : IFBLoginManager
    {
        public void LoginWithPublishPermissions(ICollection<string> permissions)
        {
            Com.Facebook.Login.LoginManager.Instance.LogInWithPublishPermissions(CrossCurrentActivity.Current.Activity, permissions);
        }

        public void LoginWithReadPermissions(ICollection<string> permissions)
        {
            Com.Facebook.Login.LoginManager.Instance.LogInWithReadPermissions(CrossCurrentActivity.Current.Activity, permissions);
        }

        public void LogOut()
        {
            Com.Facebook.Login.LoginManager.Instance.LogOut();
        }
    }
}