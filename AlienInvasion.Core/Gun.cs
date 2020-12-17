using System;
using System.Collections.Generic;
using System.Text;

namespace AlienInvasion.Core
{
    public class Gun
    {
        public int AmmunitionCount { get; private set; }

        public void Reload()
        {
            AmmunitionCount = 3;
        }

        public void Shoot(Alien alien)
        {
            AmmunitionCount--;
            alien.Kill();
        }
    }
}
