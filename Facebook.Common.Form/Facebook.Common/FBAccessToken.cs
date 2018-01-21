using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Stormlion.Facebook.Common
{
    public interface IFBAccessToken
    {
        ICollection<string> GetPermissions();

        ICollection<string> GetDeclinedPermissions();
    }

    public class FBAccessToken
    {
        protected static IFBAccessToken Impl => DependencyService.Get<IFBAccessToken>();

        public static ICollection<string> Permissions => Impl.GetPermissions();

        public static ICollection<string> DeclinedPermissions => Impl.GetDeclinedPermissions();
    }
}
