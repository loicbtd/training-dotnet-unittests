using AlienInvasion.Core;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AlienInvasion.UnitTest
{
    public class AlienShould
    {
        [Fact]
        public void NotDieIfHeIsDodging()
        {
            // Arrange
            var alienStronger = new Alien();
            var gun = new Gun();

            // Act
            alienStronger.Dodge();
            gun.Shoot(alienStronger);

            // Assert
            Assert.False(alienStronger.IsDead);
        }
    }
}
