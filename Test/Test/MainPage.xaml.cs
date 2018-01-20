using Stormlion.Facebook.Common;
using System;
using System.Collections.Generic;
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
            FBLoginManager.LoginWithReadPermissions(new List<string> { "email" });
        }
	}
}
