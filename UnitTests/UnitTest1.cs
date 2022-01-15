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
        public void GetRouteName()
        {
            int routeId = 1;
            string expected = "Маршрут #1";
            Assert.AreEqual(Functions.GetRouteName(routeId), expected);
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
        public void GetNameOfTransportTest()
        {
            int transportId = 1;
            string expected = "Avtobus";
            Assert.AreEqual(Functions.GetNameOfTransport(transportId), expected);
        }
        [TestMethod]
        public void GetNumberPlateTest()
        {
            int transportId = 1;
            string expected = "AA333AA78";
            Assert.AreEqual(Functions.GetNumberPlate(transportId), expected);
        }
    }
}