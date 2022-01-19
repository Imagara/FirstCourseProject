using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Kusach.Pages
{
    /// <summary>
    /// Логика взаимодействия для ProfilePage.xaml
    /// </summary>
    public partial class ProfilePage : Page
    {
        public ProfilePage()
        {
            InitializeComponent();
            NameSurnameBox.Content = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.Name + " " + item.Surname).FirstOrDefault();
            DateTime Birthday = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.Birthday).FirstOrDefault();
            BirthdayBox.Content = Birthday.ToLongDateString();
            string phone = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.PhoneNumber).FirstOrDefault();
            PhoneNumBox.Content = "+7(" + phone.Substring(0, 3) + ")" + phone.Substring(3, 3) + "-" + phone.Substring(6, 2) + "-" + phone.Substring(8, 2);
            EmailBox.Content = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.Email).FirstOrDefault();
        }
    }
}
