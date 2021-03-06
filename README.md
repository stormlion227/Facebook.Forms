# Facebook.Forms

Facebook SDK for Xamarin.Forms.

[![NuGet](https://img.shields.io/nuget/v/Stormlion.Facebook.Forms.svg)](https://www.nuget.org/packages/Stormlion.Facebook.Forms/)

Supports Android and iOS.

## Features

* Login and AccessToken.
* Graph API.

## Setup

* Install the [nuget package](https://www.nuget.org/packages/Stormlion.Facebook.Forms/) in portable and all platform specific projects.
* Setup all of [facebook requirments](https://developers.facebook.com/).

### Android

In MainActivity.cs file

```cs
    protected override void OnCreate(Bundle bundle)
    {
        TabLayoutResource = Resource.Layout.Tabbar;
        ToolbarResource = Resource.Layout.Toolbar;

        Stormlion.Facebook.Droid.Platform.Init(this);

        base.OnCreate(bundle);

        global::Xamarin.Forms.Forms.Init(this, bundle);
        LoadApplication(new App());
    }

    protected override void OnActivityResult(int requestCode, Result resultCode, Intent data)
    {
        Stormlion.Facebook.Droid.Platform.OnActivityResult(requestCode, resultCode, data);
        base.OnActivityResult(requestCode, resultCode, data);
    }
```

### iOS

In AppDelegate.cs file

```cs
    public override bool FinishedLaunching(UIApplication app, NSDictionary options)
    {
        global::Xamarin.Forms.Forms.Init();
        LoadApplication(new App());

        Stormlion.Facebook.iOS.Platform.FinishedLaunching(app, options);

        return base.FinishedLaunching(app, options);
    }

    public override bool OpenUrl(UIApplication app, NSUrl url, NSDictionary options)
    {
        Stormlion.Facebook.iOS.Platform.OpenUrl(app, url, options);

        return base.OpenUrl(app, url, options);
    }
```
## Usage

```cs
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

```

## Contributions
Contributions are welcome!
