using System;
using System.Collections.Generic;
using System.Text;

namespace Brainbay.Common.Entities
{
    public class Episode
    {
        public Guid ID { get; set; }
        public Guid CharacterID { get; set; }
        public string Url { get; set; }

        public Character Character { get; set; }
    }
}
