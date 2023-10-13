using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.Tests
{
    [TestClass()]
    public class PlayerTests
    {
        [TestMethod()]
        public void PlayerMovementUpdateTest()
        {
            //arrange
            Player player = new Player();
            int ancienX = player._x;

            //act & assert
            player.PlayerMovementUpdate(1 * player.Speed);
            Assert.AreEqual(player._x, ancienX + player.Speed);

            //act & assert
            player.PlayerMovementUpdate(-1 * player.Speed);
            Assert.AreEqual(player._x, ancienX);
        }

        [TestMethod()]
        public void AddAmmoTest()
        {
            //arrange
            Player player = new Player();
            int charger = player.chargerAmmo.Count;

            //act
            for (int i = charger - 1; i >= 0; i--)
            {
                player.chargerAmmo.RemoveAt(i);
            }
            player.AddAmmo(3);

            //assert
            Assert.AreEqual(3, player.chargerAmmo.Count);
        }
    }
}