using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Foundation;
using Stormlion.Facebook.Common;
using UIKit;
using Stormlion.Facebook.iOS.Binding;

namespace Facebook.Common.iOS
{
    public class FBGraphRequestImplement : IFBGraphRequest
    {
        protected string ConvertMethod(FBHttpMethod method)
        {
            switch (method)
            {
                case FBHttpMethod.GET:
                    return "GET";
                case FBHttpMethod.POST:
                    return "POST";
                default:
                    return "DELETE";
            }
        }

        public void ExecuteAsync(FBGraphRequest request)
        {
            //throw new NotImplementedException();
            new FBSDKGraphRequest(request.GraphPath, null, FBSDKAccessToken.Current.TokenString, null, ConvertMethod(request.Method)).
                StartWithCompletionHandler((connection, result, error) => {
                    request.Completed?.Invoke(result.ToString());
                });

        }
    }
}