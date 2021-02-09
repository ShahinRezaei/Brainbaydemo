using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Brainbay.Common.Entities
{
    public class Character
    {
        public Guid ID { get; set; }
        public string Name { get; set; }
        public string  Image { get; set; }
        public string Url { get; set; }
        public DateTime Created { get; set; }

        public Status Status { get; set; }
        public Species Species { get; set; }
        public CharacterType CharacterType{ get; set; }
        public Gender Gender { get; set; }
        public Origin Origin { get; set; }
        public Location Location { get; set; }
        public ICollection<Episode> Episodes { get; set; }
    }
}
