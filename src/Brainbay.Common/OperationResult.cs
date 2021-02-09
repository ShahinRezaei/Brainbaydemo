using System;
using System.Collections.Generic;
using System.Text;

namespace Brainbay.Common
{
    public class OperationResult<T>
    {
        public T Result { get; set; }
        public string  Message { get; set; }
        public OperationStatus Status { get; set; }
    }
}
