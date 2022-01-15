using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Kusach
{
    public class Functions
    {
        public static bool IsValidPhoneNumber(string phoneNumber)
        {
            foreach (char c in phoneNumber)
                if (!char.IsDigit(c))
                    return false;
            return true;
        }
        public static bool IsValidEmail(string email)
        {
            if (Regex.IsMatch(email, @"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$"))
                return true;
            else
                return false;
        }
        public static bool IsValidLogAndPass(string login, string password)
        {
            if (login == "" || password == "")
                return false;
            else
                return true;
        }
        public static string GetRouteName(int routeId)
        {
            return cnt.db.Routes.Where(item => item.IdRoute == routeId).Select(item => item.Name).FirstOrDefault();
        }
        public static bool LoginCheck(string login, string password)
        {
            if (cnt.db.Dispatcher.Select(item => item.Login + item.Password).Contains(login + Encrypt.GetHash(password)))
                return true;
            else
                return false;
        }
        public static bool IsLoginAlreadyTaken(string login)
        {
            return cnt.db.Dispatcher.Select(item => item.Login).Contains(login);
        }
        public static string GetNameOfTransport(int transportId)
        {
            return cnt.db.Transport.Where(item => item.IdTransport == transportId).Select(item => item.NameOfTransport).FirstOrDefault();
        }
        public static string GetNumberPlate(int transportId)
        {
            return cnt.db.Transport.Where(item => item.IdTransport == transportId).Select(item => item.NumberPlate).FirstOrDefault();
        }
    }
}
