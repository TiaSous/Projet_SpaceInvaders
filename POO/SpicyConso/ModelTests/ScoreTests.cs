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
    public class ScoreTests
    {
        [TestMethod()]
        public void AddScoreTest()
        {
            //arrange
            Score score = new Score();

            //act
            score.AddScore();

            //assert
            Assert.AreEqual(score._score, 10);
        }
    }
}