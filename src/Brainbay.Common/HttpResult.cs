using System;
using System.Collections.Generic;
using System.Text;

namespace Brainbay.Common
{
    public class HttpResult
    {
        public HttpRequestInfo info { get; set; }
        public CharacterDto[] results { get; set; }
    }
}
