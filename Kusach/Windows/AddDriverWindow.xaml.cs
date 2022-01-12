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

namespace Kusach
{
    /// <summary>
    /// Логика взаимодействия для AddDriverWindow.xaml
    /// </summary>
    public partial class AddDriverWindow : Window
    {
        int routeId,driverId;
        public AddDriverWindow(int id = -1)
        {
            InitializeComponent();
            routeId = id;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddDriverButton_Click(object sender, RoutedEventArgs e)
        {
            if (IdTransportBox.Text == "" || NameBox.Text == "" || SurnameBox.Text == "" || PatronymicBox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else
            {
                try
                {
                    driverId = cnt.db.Drivers.Select(p => p.IdDriver).DefaultIfEmpty(0).Max() + 1;
                    Drivers newDriver = new Drivers()
                    {
                        IdDriver = driverId,
                        IdTransport = Convert.ToInt32(IdTransportBox.Text),
                        Name = NameBox.Text,
                        Surname = SurnameBox.Text,
                        Patronymic = PatronymicBox.Text
                    };
                    cnt.db.Drivers.Add(newDriver);
                    cnt.db.SaveChanges();

                    if (routeId != -1)
                    {
                        DriversList newDriverRoute = new DriversList()
                        {
                            Id = cnt.db.DriversList.Select(p => p.Id).DefaultIfEmpty(0).Max() + 1,
                            IdDriver = driverId,
                            IdRoute = routeId
                        };
                        cnt.db.DriversList.Add(newDriverRoute);
                    }
                    cnt.db.SaveChanges();
                    MessageBox.Show("Водитель успешно создан.");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка создания водителя.");
                    this.Close();
                }
            }
        }
    }
}
