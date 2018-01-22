using System.Collections.Generic;
using Xamarin.Forms;

namespace Stormlion.Facebook
{
    public interface IFBLoginManager
    {
        void LogOut();

        void LoginWithReadPermissions(ICollection<string> permissions);

        void LoginWithPublishPermissions(ICollection<string> permissions);
    }

    public class FBLoginManager
    {
        protected static IFBLoginManager Impl => DependencyService.Get<IFBLoginManager>();

        public static void LogOut() => Impl.LogOut();

        public static void LoginWithReadPermissions(ICollection<string> permissions) => Impl.LoginWithReadPermissions(permissions);

        public static void LoginWithPublishPermissions(ICollection<string> permissions) => Impl.LoginWithPublishPermissions(permissions);

        public static FBFacebookCallback CallBack { get; set; }
    }
}
