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
            string phoneNum = "9996194949";
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
            Assert.AreEqual(Functions.GetRouteName(routeId),expected);
        }
    }
}
