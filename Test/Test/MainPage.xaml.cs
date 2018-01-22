using Stormlion.Facebook;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Test
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MainPage : ContentPage
	{
		public MainPage()
		{
			InitializeComponent();
		}

        protected void OnLoginClicked(object sender, EventArgs e)
        {
            FBLoginManager.CallBack = new FBFacebookCallback
            {
                Success = () =>
                {
                    Debug.WriteLine("Success!");
                    new FBGraphRequest
                    {
                        GraphPath = "me",
                        Method = FBHttpMethod.GET,
                        Parameters = new Dictionary<string, string>
                        {
                            {"fields", "email, first_name, last_name, gender" }
                        },
                        Completed = (response) =>
                        {
                            Debug.WriteLine(response);
                        }
                    }.ExecuteAsync();
                },
                Cancel = () =>
                {
                    Debug.WriteLine("Cancel!");
                },
                Error = () =>
                {
                    Debug.WriteLine("Errror!");
                }
            };

            FBLoginManager.LoginWithReadPermissions(new List<string> { "public_profile" });
        }
	}
}
