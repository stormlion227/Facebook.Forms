using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Stormlion.Facebook
{
    public interface IFBGraphRequest
    {
        void ExecuteAsync(FBGraphRequest request);
    }

    public class FBGraphRequest
    {
        public string GraphPath { get; set; }

        public FBHttpMethod Method { get; set; }

        public Action<string> Completed { get; set; }

        public void ExecuteAsync()
        {
            DependencyService.Get<IFBGraphRequest>().ExecuteAsync(this);
        }
    }
}
