using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;

using Stormlion.Facebook.iOS.Binding;
using Stormlion.Facebook.Common;
using System.Diagnostics;

namespace Facebook.Common.iOS
{
    public class FBLoginManagerImplement : IFBLoginManager
    {
        public void LoginWithPublishPermissions(ICollection<string> permissions)
        {
            //throw new NotImplementedException();
            FBSDKLoginManager login = new FBSDKLoginManager();

            string[] arrayPermissions = new string[permissions.Count];
            permissions.CopyTo(arrayPermissions, 0);

            login.LogInWithPublishPermissions(arrayPermissions, UIApplication.SharedApplication.KeyWindow.RootViewController, (result, error) => {
                if (result != null)
                {
                    if (result.IsCancelled)
                    {
                        FBLoginManager.CallBack?.Cancel?.Invoke();
                    }
                    else
                    {
                        FBLoginManager.CallBack?.Success?.Invoke();
                    }
                }
                else
                {
                    FBLoginManager.CallBack?.Error?.Invoke();
                }
            });
        }

        public void LoginWithReadPermissions(ICollection<string> permissions)
        {
            //throw new NotImplementedException();
            FBSDKLoginManager login = new FBSDKLoginManager();

            string[] arrayPermissions = new string[permissions.Count];
            permissions.CopyTo(arrayPermissions, 0);

            login.LogInWithReadPermissions(arrayPermissions, UIApplication.SharedApplication.KeyWindow.RootViewController, (result, error) => {
                if(result != null)
                {
                    if (result.IsCancelled)
                    {
                        FBLoginManager.CallBack?.Cancel?.Invoke();
                    }
                    else
                    {
                        FBLoginManager.CallBack?.Success?.Invoke();
                    }
                }
                else
                {
                    FBLoginManager.CallBack?.Error?.Invoke();
                }
            });
        }

        public void LogOut()
        {
            //throw new NotImplementedException();
            FBSDKLoginManager login = new FBSDKLoginManager();

            login.LogOut();
        }
    }
}