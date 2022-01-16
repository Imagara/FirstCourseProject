using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Kusach;
namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void IsValidPhoneNumber()
        {
            string phoneNum = "9999194949";
            Assert.IsTrue(Functions.IsValidPhoneNumber(phoneNum));
        }
        [TestMethod]
        public void IsValidEmail()
        {
            string email = "lalka@gmail.com";
            Assert.IsTrue(Functions.IsValidEmail(email));
        }
        [TestMethod]
        public void PasswordEncryptTest()
        {
            string password = "lalka";
            string expected = "55B6F08EFCE1438F38323E02C7C451FBD1E1AA12";
            Assert.AreEqual(Encrypt.GetHash(password), expected);
        }
        [TestMethod]
        public void LoginTest()
        {
            string login = "qq";
            string password = "qq";
            Assert.IsTrue(Functions.LoginCheck(login, password));
        }
        [TestMethod]
        public void IsValidLoginAndPassword()
        {
            Assert.IsTrue(Functions.IsValidLogAndPass("qq", "ww"));
            Assert.IsTrue(Functions.IsValidLogAndPass("laq", "wwadsw"));
            Assert.IsFalse(Functions.IsValidLogAndPass("", ""));
            Assert.IsFalse(Functions.IsValidLogAndPass("", "SimplePass"));
            Assert.IsFalse(Functions.IsValidLogAndPass("SimpleLogin", ""));
        }
        [TestMethod]
        public void IsLoginAlreadyTaken()
        {
            Assert.IsTrue(Functions.IsLoginAlreadyTaken("qq"));
        }
        [TestMethod]
        public void GetNameOfTransportUsingId()
        {
            int transportId = 1;
            string expected = "Avtobus";
            Assert.AreEqual(Functions.GetNameOfTransport(transportId), expected);
        }
        [TestMethod]
        public void GetNumberPlateUsingId()
        {
            int transportId = 1;
            string expected = "AA333AA78";
            Assert.AreEqual(Functions.GetNumberPlate(transportId), expected);
        }
        [TestMethod]
        public void GetRouteNameUsingId()
        {
            int routeId = 1;
            string expected = "Маршрут #1";
            Assert.AreEqual(Functions.GetRouteName(routeId), expected);
        }
        [TestMethod]
        public void GetNameOfPointUsingId()
        {
            int pointId = 1;
            string expected = "Томская";
            Assert.AreEqual(Functions.GetNameOfPoint(pointId), expected);
        }
        [TestMethod]
        public void GetLocationOfPointUsingId()
        {
            int pointId = 1;
            string expected = "Томская, 21";
            Assert.AreEqual(Functions.GetLocationOfPoint(pointId), expected);
        }
        [TestMethod]
        public void IsValidNameAndLocationOfPoint()
        {
            string Name = "Томская";
            string Location = "Томская, 21";
            Assert.IsTrue(Functions.IsValidNameAndLocationOfPoint(Name, Location));
        }
        [TestMethod]
        public void IsValidInfoAboutDriver()
        {
            string IdTransport = "1";
            string name = "Петр";
            string surname = "Некрасов";
            string patronymic = "Антонович";
            Assert.IsTrue(Functions.IsValidInfoAboutDriver(IdTransport, name, surname, patronymic));
        }
        [TestMethod]
        public void IsIdOnlyDigits()
        {
            string IdTransport = "123";
            Assert.IsTrue(Functions.IsIdOnlyDigits(IdTransport));
        }
    }
}