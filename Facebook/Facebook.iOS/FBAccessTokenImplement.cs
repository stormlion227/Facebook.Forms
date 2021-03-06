﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using UIKit;
using Stormlion.Facebook.iOS.Binding;

namespace Stormlion.Facebook.iOS
{
    public class FBAccessTokenImplement : IFBAccessToken
    {
        public ICollection<string> GetDeclinedPermissions()
        {
            return (ICollection<string>)(FBSDKAccessToken.Current.DeclinedPermissions);
        }

        public ICollection<string> GetPermissions()
        {
            return (ICollection<string>)(FBSDKAccessToken.Current.Permissions);
        }
    }
}