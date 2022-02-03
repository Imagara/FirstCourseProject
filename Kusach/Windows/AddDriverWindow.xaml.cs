using System;
using System.Linq;
using System.Windows;

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
            if (NumberPlateBox.Text == "" || NameBox.Text == "" || SurnameBox.Text == "" || PatronymicBox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
           // if(cnt.db.Transport.Select(item => item.NumberPlate).Contains(NumberPlateBox.Text))
           //     MessageBox.Show("Неверно введен номерной знак");
            else
            {
                try
                {
                    driverId = cnt.db.Drivers.Select(p => p.IdDriver).DefaultIfEmpty(0).Max() + 1;
                    Drivers newDriver = new Drivers()
                    {
                        IdDriver = driverId,
                        IdTransport = Convert.ToInt32(cnt.db.Transport.Where(item => item.NumberPlate == NumberPlateBox.Text).Select(item => item.IdTransport).FirstOrDefault()),
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
