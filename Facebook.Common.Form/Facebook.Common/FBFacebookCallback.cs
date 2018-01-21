using System;
using System.Collections.Generic;
using System.Text;

namespace Stormlion.Facebook.Common
{
    public class FBFacebookCallback
    {
        public Action Success { get; set; }

        public Action Cancel { get; set; }

        public Action Error { get; set; }
    }
}
