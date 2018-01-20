using Android.Content;
using Stormlion.Facebook.Login;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(FBLoginButton), typeof(Stormlion.Facebook.Login.Droid.Renderer.FBLoginButtonRenderer))]
namespace Stormlion.Facebook.Login.Droid.Renderer
{
    public class FBLoginButtonRenderer : ButtonRenderer
    {
        public FBLoginButtonRenderer(Context context) : base(context)
        {
        }

        protected override Android.Widget.Button CreateNativeControl()
        {
            return new Com.Facebook.Login.Widget.LoginButton(Context);
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);
        }
    }
}