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
    public class AmmoTests
    {
        [TestMethod()]
        public void AmmoUpdateTest()
        {
            //arrange
            Ammo ammo = new Ammo();
            int ancienY = ammo._y;

            //act
            ammo.AmmoUpdate();

            //assert
            Assert.AreEqual(ammo._y, ancienY - 1);
        }
    }
}