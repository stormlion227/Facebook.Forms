using System;
using System.Threading.Tasks;
using Com.Facebook;

namespace Stormlion.Facebook.Common.Droid
{
    public class FBGraphRequestImplement : IFBGraphRequest
    {
        protected Com.Facebook.HttpMethod ConvertMethod(FBHttpMethod method)
        {
            switch(method)
            {
                case FBHttpMethod.GET:
                    return Com.Facebook.HttpMethod.Get;
                case FBHttpMethod.POST:
                    return Com.Facebook.HttpMethod.Post;
                default:
                    return Com.Facebook.HttpMethod.Delete;
            }
        }

        public void ExecuteAsync(FBGraphRequest request)
        {
            new Com.Facebook.GraphRequest(
                Com.Facebook.AccessToken.CurrentAccessToken,
                request.GraphPath,
                null,
                ConvertMethod(request.Method),
                new FBGraphCallback
                {
                    Action = request.Completed
                }
                ).ExecuteAsync();
        }

        public class FBGraphCallback : Java.Lang.Object, Com.Facebook.GraphRequest.ICallback
        {
            public Action<string> Action { get; set; }

            public void OnCompleted(GraphResponse p0)
            {
                Action?.Invoke(p0.RawResponse);
            }
        }
    }
}