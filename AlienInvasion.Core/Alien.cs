using System;

namespace AlienInvasion.Core
{
    public class Alien
    {
        public bool isDodging;

        public bool IsDead { get; private set; }

        public void Dodge()
        {
            isDodging = true;
        }

        public void Kill()
        {
            IsDead = !isDodging;
        }
    }
}
