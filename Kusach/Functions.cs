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
        public static string GetRouteName(int routeId)
        {
            return cnt.db.Routes.Where(item => item.IdRoute == routeId).Select(item => item.Name).FirstOrDefault();
        }
    }
}
