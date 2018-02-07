using Android.App;
using Com.Facebook;
using Java.Lang;
using System;
using System.Collections.Generic;

namespace Stormlion.Facebook.Droid
{
    public class FBLoginManagerImplement : IFBLoginManager
    {
        protected FBLoginManagerCallback callback = new FBLoginManagerCallback();

        public void LoginWithPublishPermissions(ICollection<string> permissions)
        {
            if (FBLoginManager.CallBack != null)
            {
                Com.Facebook.Login.LoginManager.Instance.RegisterCallback(
                    Stormlion.Facebook.Droid.Platform.CallBackManager,
                    callback);
            }

            Com.Facebook.Login.LoginManager.Instance.LogInWithPublishPermissions((Activity)Platform.Context, permissions);
        }

        public void LoginWithReadPermissions(ICollection<string> permissions)
        {
            if (FBLoginManager.CallBack != null)
            {
                Com.Facebook.Login.LoginManager.Instance.RegisterCallback(
                    Stormlion.Facebook.Droid.Platform.CallBackManager,
                    callback);
            }

            Com.Facebook.Login.LoginManager.Instance.LogInWithReadPermissions((Activity)Platform.Context, permissions);
        }

        public void LogOut()
        {
            Com.Facebook.Login.LoginManager.Instance.LogOut();
        }
    }

    public class FBLoginManagerCallback : Java.Lang.Object, Com.Facebook.IFacebookCallback
    {
        public void OnCancel()
        {
            FBLoginManager.CallBack?.Cancel?.Invoke();
        }

        public void OnError(FacebookException p0)
        {
            FBLoginManager.CallBack?.Error?.Invoke();
        }

        public void OnSuccess(Java.Lang.Object p0)
        {
            FBLoginManager.CallBack?.Success?.Invoke();
        }
    }
}