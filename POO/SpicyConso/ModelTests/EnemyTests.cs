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
    public class EnemyTests
    {
        [TestMethod()]
        public void UpdateEnemyTest()
        {
            //arrange
            Enemy enemy = new Enemy(0);
            int ancienX = enemy._x;

            //assert & act pour déplacement à droite
            enemy.UpdateEnemy();
            Assert.AreEqual(ancienX + 1, enemy._x);

            //assert & act pour déplacement à gauche
            enemy.Down();
            enemy.UpdateEnemy();
            Assert.AreEqual(ancienX, enemy._x);
        }

        [TestMethod()]
        public void DownTest()
        {           
            //arrange
            Enemy enemy = new Enemy(0);
            int ancienY = enemy._y;

            //assert & act
            enemy.Down();
            Assert.AreEqual(ancienY + 2, enemy._y);
        }
    }
}