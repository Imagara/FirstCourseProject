using System;
using System.Linq;
using System.Windows;
namespace Kusach.Windows
{
    /// <summary>
    /// Логика взаимодействия для DriverEditWindow.xaml
    /// </summary>
    public partial class DriverEditWindow : Window
    {
        int driverId;
        public DriverEditWindow(int id)
        {
            InitializeComponent();
            driverId = id;
            NumberPlate.Text = cnt.db.Drivers.Where(item => item.IdDriver == driverId).Select(item => item.Transport.NumberPlate).FirstOrDefault().ToString();
            SurnameBox.Text = cnt.db.Drivers.Where(item => item.IdDriver == driverId).Select(item => item.Surname).FirstOrDefault();
            NameBox.Text = cnt.db.Drivers.Where(item => item.IdDriver == driverId).Select(item => item.Name).FirstOrDefault();
            PatronymicBox.Text = cnt.db.Drivers.Where(item => item.IdDriver == driverId).Select(item => item.Patronymic).FirstOrDefault();
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveDriverButton_Click(object sender, RoutedEventArgs e)
        {
            Drivers driver = cnt.db.Drivers.Where(item => item.IdDriver == driverId).FirstOrDefault();
            driver.Name = NameBox.Text;
            driver.IdTransport = Convert.ToInt32(cnt.db.Transport.Where(item => item.NumberPlate == NumberPlate.Text).Select(item => item.IdTransport).FirstOrDefault());
            driver.Surname = SurnameBox.Text;
            driver.Name = NameBox.Text;
            driver.Patronymic = PatronymicBox.Text;
            cnt.db.SaveChanges();
            this.Close();
        }
    }
}
