using System;

namespace AlienInvasion.Core
{
    public class Alien
    {
        public bool IsDead { get; private set; }

        public void Kill()
        {
            IsDead = true;
        }
    }
}
