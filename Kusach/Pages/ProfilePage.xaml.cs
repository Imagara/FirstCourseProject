using Microsoft.Win32;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace Kusach.Pages
{
    public partial class ProfilePage : Page
    {
        Dispatcher dispatcher;
        public ProfilePage()
        {
            InitializeComponent();
            dispatcher = cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).FirstOrDefault();
            if (cnt.db.Dispatcher.Where(item => item.IdDispatcher == profile.DispatcherId).Select(item => item.ProfileImgSource).FirstOrDefault() != null)
                ProfileImg.Source = new BitmapImage(new Uri(dispatcher.ProfileImgSource));
            NameSurnameBox.Content = dispatcher.Name + " " + dispatcher.Surname;
            BirthdayBox.Content = dispatcher.Birthday.ToLongDateString();
            PhoneNumBox.Content = "+7(" + dispatcher.PhoneNumber.Substring(0, 3) + ")" + dispatcher.PhoneNumber.Substring(3, 3) + "-" + dispatcher.PhoneNumber.Substring(6, 2) + "-" + dispatcher.PhoneNumber.Substring(8, 2);
            EmailBox.Content = dispatcher.Email;
        }
        private void EditImageButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".png";
            ofd.Filter = "JPEG Files (*.jpeg)|*.jpeg|PNG Files (*.png)|*.png|JPG Files (*.jpg)|*.jpg";
            Nullable<bool> result = ofd.ShowDialog();
            if (result == true)
            {
                string filename = ofd.FileName;
                ProfileImg.Source = new BitmapImage(new Uri(filename));
                dispatcher.ProfileImgSource = filename;
                cnt.db.SaveChanges();
            }
        }
    }
}
