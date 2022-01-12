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
using System.Windows.Shapes;

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
            IdTransportBox.Text = cnt.db.Drivers.Where(item => item.IdDriver == driverId).Select(item => item.IdTransport).FirstOrDefault().ToString();
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
            driver.IdTransport = Convert.ToInt32(IdTransportBox.Text);
            driver.Surname = SurnameBox.Text;
            driver.Name = NameBox.Text;
            driver.Patronymic = PatronymicBox.Text;
            cnt.db.SaveChanges();
            this.Close();
        }
    }
}
