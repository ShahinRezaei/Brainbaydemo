using System;
using System.Collections.Generic;
using System.Text;

namespace Brainbay.Common.Entities
{
    public class Gender
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<Character> Characters { get; set; }
    }

    /*
     Male
     Female
     unknown
     Genderless

     */
}
