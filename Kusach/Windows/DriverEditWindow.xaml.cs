using System;
using System.Linq;
using System.Windows;
namespace Kusach.Windows
{
    public partial class DriverEditWindow : Window
    {
        Drivers driver;
        public DriverEditWindow(int id)
        {
            InitializeComponent();
            driver = cnt.db.Drivers.Where(item => item.IdDriver == id).FirstOrDefault();
            NumberPlate.Text = driver.Transport.NumberPlate.ToString();
            SurnameBox.Text = driver.Surname;
            NameBox.Text = driver.Name;
            PatronymicBox.Text = driver.Patronymic;
        }
        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        private void SaveDriverButton_Click(object sender, RoutedEventArgs e)
        {
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
