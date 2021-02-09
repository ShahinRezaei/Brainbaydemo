using System;
using System.Collections.Generic;
using System.Text;

namespace Brainbay.Common
{
    public class HttpRequestInfo
    {
        public int Count { get; set; }
        public int Pages { get; set; }
        public string Next { get; set; }
        public string Prev { get; set; }
    }
}
