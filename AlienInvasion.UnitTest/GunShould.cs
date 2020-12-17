using AlienInvasion.Core;
using System;
using Xunit;

namespace AlienInvasion.UnitTest
{
    public class GunShould
    {
        [Fact]
        public void KillAlien()
        {
            // Arrange
            var alien = new Alien();
            var gun = new Gun();

            // Act
            gun.Shoot(alien);

            // Assert
            Assert.True(alien.IsDead);
        }
    }
}
