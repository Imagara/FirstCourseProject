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
    /// Логика взаимодействия для AddRouteWindow.xaml
    /// </summary>
    public partial class AddRouteWindow : Window
    {
        public AddRouteWindow()
        {
            InitializeComponent();
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            if (RouteNameBox.Text == "")
                MessageBox.Show("Поля не могут быть пустыми.");
            else
            {
                try
                {
                    Routes newRoute = new Routes()
                    {
                        IdRoute = cnt.db.Routes.Count() + 1,
                        Name = RouteNameBox.Text
                    };
                    cnt.db.Routes.Add(newRoute);
                    cnt.db.SaveChanges();
                    MessageBox.Show("Маршрут успешно создан.");
                    this.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка создания маршрута.");
                    this.Close();
                }
            }
        }
    }
}
