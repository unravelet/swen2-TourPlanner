using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourPlanner.BL.Services;

namespace TourPlanner.Test {
    public class UserInputTests {
        [Test]
        public void IsInputIntTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string input = "13";


            //assert
            Assert.IsTrue(uiService.IsInputInt(input));

        }

        [Test]
        public void IsInputInt2Test() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string input = "input3";


            //assert
            Assert.IsFalse(uiService.IsInputInt(input));

        }

        [Test]
        public void IsZipTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = 1200;


            //assert
            Assert.IsTrue(uiService.IsZip(input));

        }

        [Test]
        public void IsNotZipTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = -2;


            //assert
            Assert.IsFalse(uiService.IsZip(input));

        }


        [Test]
        public void IsNotAddressNumberTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = -6;


            //assert
            Assert.IsFalse(uiService.IsAddressNumber(input));

        }

        [Test]
        public void IsNotAddressNumberTest2() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = 986040;


            //assert
            Assert.IsFalse(uiService.IsAddressNumber(input));

        }

        [Test]
        public void IsAddressNumberTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            int input = 986039;


            //assert
            Assert.IsTrue(uiService.IsAddressNumber(input));

        }

        [Test]
        public void CanCreateTourFalseTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string name = "  ";
            string startAdd = "a";
            string startAddNum = "3";
            string startZip = "1200";
            string startCity = "a";
            string startCountry = "";

            string endAdd = "f";
            string endAddNum = "3";
            string endZip = "1200";
            string endCity = "f";
            string endCountry = "  ";



            //assert
            Assert.IsFalse(uiService.CanCreateTour(name, startAdd, startAddNum,
                startZip, startCountry, endAdd, endAddNum, endZip, endCountry, 
                startCity, endCity));

        }

        [Test]
        public void CanCreateTourAllEmptyTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string name = "";
            string startAdd = "  ";
            string startAddNum = "";
            string startZip = "";
            string startCity = "";
            string startCountry = "";

            string endAdd = "";
            string endAddNum = "";
            string endZip = "";
            string endCity = "";
            string endCountry = "";


            //assert
            Assert.IsFalse(uiService.CanCreateTour(name, startAdd, startAddNum,
                startZip, startCountry, endAdd, endAddNum, endZip, endCountry,
                startCity, endCity));

        }

        [Test]
        public void CanCreateTourTrueTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            
            string name = "a";
            string startAdd = "a";
            string startAddNum = "3";
            string startZip = "1200";
            string startCity = "a";
            string startCountry = "a";

            string endAdd = "f";
            string endAddNum = "3";
            string endZip = "1200";
            string endCity = "f";
            string endCountry = "f";



            //assert
            Assert.IsTrue(uiService.CanCreateTour(name, startAdd, startAddNum,
                startZip, startCountry, endAdd, endAddNum, endZip, endCountry,
                startCity, endCity));

        }

        [Test]
        public void CanCreateTourLogFalseTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string date = "23.5.22";
            string duration = "6h";
            string distance = "";
            string rating = "2";
            string difficulty = "6";
            


            //assert
            Assert.IsFalse(uiService.CanCreateTourLog(date, duration, distance,
                rating, difficulty));

        }

        [Test]
        public void CanCreateTourLogTrueTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string date = "23.5.22";
            string duration = "6h";
            string distance = "3km";
            string rating = "2";
            string difficulty = "6";



            //assert
            Assert.IsTrue(uiService.CanCreateTourLog(date, duration, distance,
                rating, difficulty));

        }

        [Test]
        public void CanCreateTourLogAllEmptyTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string date = " ";
            string duration = " ";
            string distance = " ";
            string rating = "";
            string difficulty = "";



            //assert
            Assert.IsFalse(uiService.CanCreateTourLog(date, duration, distance,
                rating, difficulty));

        }

        [Test]
        public void ParseInputToIntTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string input = "56";
            int parsed = uiService.ParseInputToInt(input);


            //assert
            Assert.AreEqual(parsed, 56);

        }

        [Test]
        public void ParseInputToIntFailTest() {
            //arrange
            UserInputService uiService = new UserInputService();

            //act
            string input = "56ff";
            int parsed = uiService.ParseInputToInt(input);

            //assert
            Assert.AreEqual(parsed,0);

        }


    }
}
