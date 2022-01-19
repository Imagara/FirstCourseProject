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
            if(cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.ProfileImgSource).FirstOrDefault() != null)
            ProfileImg.Source = new BitmapImage(new Uri(cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.ProfileImgSource).FirstOrDefault()));
            NameSurnameBox.Content = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.Name + " " + item.Surname).FirstOrDefault();
            DateTime Birthday = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.Birthday).FirstOrDefault();
            BirthdayBox.Content = Birthday.ToLongDateString();
            string phone = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.PhoneNumber).FirstOrDefault();
            PhoneNumBox.Content = "+7(" + phone.Substring(0, 3) + ")" + phone.Substring(3, 3) + "-" + phone.Substring(6, 2) + "-" + phone.Substring(8, 2);
            EmailBox.Content = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.Email).FirstOrDefault();
        }
        private void EditImageButton_Click(object sender, RoutedEventArgs e)
        {
            // Создаем OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();

            // Устанавливаем фильтры и стандартное расширение файла
            dlg.DefaultExt = ".png";
            dlg.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";

            // Отображаем OpenFileDialog
            Nullable<bool> result = dlg.ShowDialog();

            // Получаем и устанавливаем новое изображение 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;
                ProfileImg.Source = new BitmapImage(new Uri(filename));
                Dispatcher dispatcher = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).FirstOrDefault();
                dispatcher.ProfileImgSource = filename;
                cnt.db.SaveChanges();
            }
        }
    }
}
