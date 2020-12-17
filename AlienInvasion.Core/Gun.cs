using System;
using System.Collections.Generic;
using System.Text;

namespace AlienInvasion.Core
{
    public class Gun
    {
        public void Shoot(Alien alien)
        {
            alien.Kill();
        }
    }
}
