using System;
using System.Collections.Generic;
using System.Text;

namespace Brainbay.Common.Entities
{
    public class Species
    {
        public Guid ID { get; set; }
        public string Name { get; set; }

        public ICollection<Character> Characters { get; set; }
    }


    /*
     Alive
     unknown
     Dead
     */


    /*
     
        Human
        Alien
        Humanoid
        unknown
        Poopybutthole
        Mythological Creature
        Animal
        Robot
        Cronenberg
        Disease
        Planet

     */
}
