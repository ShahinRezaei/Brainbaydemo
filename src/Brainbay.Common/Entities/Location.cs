using System;
using System.Collections.Generic;
using System.Text;

namespace Brainbay.Common.Entities
{
    public class Location
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public ICollection<Character> Characters { get; set; }
    }
}
