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
            Player player = new Player();
            int ancienX = player._x;
            player.PlayerMovementUpdate(1 * player.Speed);
            Assert.AreEqual(player._x, ancienX + player.Speed);
            ancienX = player._x;
            player.PlayerMovementUpdate(-1 * player.Speed);
            Assert.AreEqual(player._x, ancienX - player.Speed);
        }
    }
}