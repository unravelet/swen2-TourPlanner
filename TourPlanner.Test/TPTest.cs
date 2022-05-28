using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TourPlanner.BL.Services;
using TourPlanner.BL;
using TourPlanner.Models;

namespace TourPlanner.Test {
    public class TPTest {

        [Test]
        public void IsInputInt() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string input = "13";


            //assert
            Assert.IsTrue(uiService.IsInputInt(input));

        }

        [Test]
        public void IsInputInt2() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string input = "input";


            //assert
            Assert.IsFalse(uiService.IsInputInt(input));

        }

        [Test]
        public void IsZip() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = 1200;


            //assert
            Assert.IsTrue(uiService.IsZip(input));

        }

        [Test]
        public void IsNotZip() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = 2;


            //assert
            Assert.IsFalse(uiService.IsZip(input));

        }


        [Test]
        public void IsNotAddressNumber() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = -6;


            //assert
            Assert.IsFalse(uiService.IsAddressNumber(input));

        }

        [Test]
        public void IsNotAddressNumber2() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = 986040;


            //assert
            Assert.IsFalse(uiService.IsAddressNumber(input));

        }

        [Test]
        public void IsAddressNumber() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = 986039;


            //assert
            Assert.IsTrue(uiService.IsAddressNumber(input));

        }
    }
}
